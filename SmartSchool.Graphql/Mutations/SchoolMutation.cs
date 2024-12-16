using AutoMapper;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using SmartSchool.Graphql.Helpers;
using SmartSchool.Graphql.Inputs;
using SmartSchool.Graphql.Models;
using SmartSchool.Graphql.Subscriptions;
using SmartSchool.Schema;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using SmartSchool.Service.Services;

namespace SmartSchool.Graphql.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class SchoolMutation
    {
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly long userId = 1;

        public SchoolMutation(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor
        )
        {
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            var headers = httpContextAccessor.HttpContext?.Request.Headers;
            if (headers?.TryGetValue("User-Id", out var userIdValue) == true && long.TryParse(userIdValue, out var userId))
            {
                this.userId = userId;
            }
        }

        public async Task<SchoolModel> CreateSchoolAsync(AppDbContext dbContext, [Service] ITopicEventSender sender, SchoolInput input)
        {
            var existingRecord = await dbContext.Schools
                .FirstOrDefaultAsync(x => x.CensusNo == input.CensusNo);
            if (existingRecord != null)
            {
                throw new InvalidOperationException($"The {nameof(School.CensusNo)} '{input.CensusNo}' has been already registered for the school '{existingRecord.Name}'.");
            }

            var newRecord = await MutationHelper.CreateRecordAsync<School, SchoolInput, SchoolModel>(dbContext, input);
            await sender.SendAsync(nameof(SchoolSubscription.SchoolProcessed), newRecord);
            return newRecord;
        }

        public async Task<SchoolModel> UpdateSchoolAsync(AppDbContext dbContext, SchoolInput input)
        {
            ArgumentNullException.ThrowIfNull(input.Id);

            var existingRecord = await dbContext.Schools
                .FirstOrDefaultAsync(x => x.Id != input.Id && x.CensusNo == input.CensusNo);

            if (existingRecord != null)
            {
                throw new InvalidOperationException($"The {nameof(School.CensusNo)} '{input.CensusNo}' has been already registered for the school '{existingRecord.Name}'.");
            }

            return await MutationHelper.UpdateRecordAsync<School, SchoolInput, SchoolModel>(dbContext, input);
        }

        public async Task<SchoolStudentEnrollmentRequestModel> CreateSchoolStudentEnrollmentRequestAsync(AppDbContext dbContext, [Service] ITopicEventSender sender, SchoolStudentEnrollmentRequestInput input)
        {
            var filteredRequestStatuses = new List<RequestStatus>() { RequestStatus.Pending, RequestStatus.Processing, RequestStatus.OnHold };
            var existingRequest = await dbContext.SchoolStudentEnrollmentRequests
                .Include(x => x.School)
                .Include(x => x.Person)
                .Where(x => x.SchoolId == input.SchoolId && x.PersonId == input.PersonId && filteredRequestStatuses.Contains(x.Status))
                .OrderByDescending(x => x.CreatedTime)
                .FirstOrDefaultAsync();

            if (existingRequest != null)
            {
                throw new InvalidOperationException($"The person '{existingRequest.Person.FullName}' has already requested enrollment at the school '{existingRequest.School.Name}'.");
            }

            var filteredEnrollmentStatuses = new List<EnrollmentStatus>() { EnrollmentStatus.Active, EnrollmentStatus.Rejoined };
            var existingEnrollment = await dbContext.SchoolStudentEnrollments
                .Include(x => x.School)
                .Include(x => x.Student.Person)
                .Where(x => x.Student.Person.Id == input.PersonId && filteredEnrollmentStatuses.Contains(x.Status))
                .OrderByDescending(x => x.CreatedTime)
                .FirstOrDefaultAsync();

            if (existingEnrollment != null)
            {
                throw new InvalidOperationException($"The person '{existingEnrollment.Student.Person.FullName}' has already has an active enrollment at the school '{existingEnrollment.School.Name}'.");
            }

            var newRecord = mapper.Map<SchoolStudentEnrollmentRequest>(input);
            newRecord.Status = RequestStatus.Pending;
            dbContext.SchoolStudentEnrollmentRequests.Add(newRecord);
            await dbContext.SaveChangesAsync();
            await sender.SendAsync(nameof(SchoolSubscription.SchoolStudentEnrollmentRequestProcessed), mapper.Map<SchoolStudentEnrollmentRequestModel>(newRecord));

            return mapper.Map<SchoolStudentEnrollmentRequestModel>(newRecord);
        }

        public async Task<SchoolStudentEnrollmentRequestModel> UpdateSchoolStudentEnrollmentRequestAsync(AppDbContext dbContext, [Service] ITopicEventSender sender, SchoolStudentEnrollmentRequestInput input)
        {
            ArgumentNullException.ThrowIfNull(input.Id);

            var existingRecord = await dbContext.SchoolStudentEnrollmentRequests.FindAsync(input.Id.Value) ?? throw new KeyNotFoundException($"No matching record found (id={input.Id.Value})");

            mapper.Map(input, existingRecord);
            await dbContext.SaveChangesAsync();
            await sender.SendAsync(nameof(SchoolSubscription.SchoolStudentEnrollmentRequestProcessed), mapper.Map<SchoolStudentEnrollmentRequestModel>(existingRecord));

            return mapper.Map<SchoolStudentEnrollmentRequestModel>(existingRecord);
        }

        public async Task<SchoolStudentEnrollmentRequestModel> UpdateSchoolStudentEnrollmentRequestStatusAsync(AppDbContext dbContext, [Service] ITopicEventSender sender, SchoolStudentEnrollmentRequestStatusUpdateInput input)
        {
            ArgumentNullException.ThrowIfNull(input.Id);

            var existingRecord = await dbContext.SchoolStudentEnrollmentRequests.FindAsync(input.Id.Value) ?? throw new KeyNotFoundException($"No matching record found (id={input.Id.Value})");

            existingRecord.Status = input.Status;
            existingRecord.Reason = input.Reason;
            await dbContext.SaveChangesAsync();
            await sender.SendAsync(nameof(SchoolSubscription.SchoolStudentEnrollmentRequestProcessed), mapper.Map<SchoolStudentEnrollmentRequestModel>(existingRecord));

            return mapper.Map<SchoolStudentEnrollmentRequestModel>(existingRecord);
        }

        public async Task<SchoolStudentEnrollmentModel> CreateSchoolStudentEnrollmentAsync(AppDbContext dbContext, [Service] ITopicEventSender sender, SchoolStudentEnrollmentInput input)
        {
            var schoolStudentEnrollmentRequest = null as SchoolStudentEnrollmentRequest;

            if (input.SchoolStudentEnrollmentRequestId.HasValue)
            {
                schoolStudentEnrollmentRequest = await dbContext.SchoolStudentEnrollmentRequests
                .FirstOrDefaultAsync(x => x.Id == input.SchoolStudentEnrollmentRequestId) ?? throw new KeyNotFoundException($"No matching School Student Enrollment Request record found (id={input.SchoolStudentEnrollmentRequestId})");
            }

            var existingSchool = await dbContext.Schools
                .FirstOrDefaultAsync(x => x.Id == input.SchoolId) ?? throw new KeyNotFoundException($"No matching School record found (id={input.SchoolId})");

            var existingPerson = await dbContext.Persons
                .Include(x => x.Student)
                .FirstOrDefaultAsync(x => x.Id == input.PersonId) ?? throw new KeyNotFoundException($"No matching Person record found (id={input.PersonId})");

            var existingClass = await dbContext.Classes
                .FirstOrDefaultAsync(x => x.Id == input.ClassId) ?? throw new KeyNotFoundException($"No matching Class record found (id={input.ClassId})");

            var existingAcademicYear = await dbContext.AcademicYears
                .FirstOrDefaultAsync(x => x.Year == input.AcademicYearYear) ?? throw new KeyNotFoundException($"No matching Academic Year record found (year={input.AcademicYearYear})");

            var newSchoolStudentEnrollment = mapper.Map<SchoolStudentEnrollment>(input);

            bool success = false;
            const int maxRetries = 3;
            int attempt = 0;

            using var transaction = await dbContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);

            var student = existingPerson.Student;

            if (student == null)
            {
                student = new Student { Person = existingPerson };
                await dbContext.Students.AddAsync(student);
                await dbContext.SaveChangesAsync();
            }

            while (!success && attempt < maxRetries)
            {
                attempt++;

                try
                {
                    if (schoolStudentEnrollmentRequest != null)
                    {
                        schoolStudentEnrollmentRequest.Status = RequestStatus.Approved;
                        await dbContext.SaveChangesAsync();
                    }

                    // Get the latest AdmissionNo for the specified SchoolId within the transaction
                    var latestSchoolStudentEnrollment = await dbContext.SchoolStudentEnrollments
                        .Where(a => a.SchoolId == newSchoolStudentEnrollment.SchoolId)
                        .OrderByDescending(a => a.No)
                        .FirstOrDefaultAsync();

                    // Determine the new AdmissionCode
                    int newNo = latestSchoolStudentEnrollment != null ? latestSchoolStudentEnrollment.No + 1 : 1;

                    // Assign the new AdmissionCode to the Admission entity
                    newSchoolStudentEnrollment.No = newNo/*.ToString("D5")*/; // E.g., "00001", "00002", etc.
                    newSchoolStudentEnrollment.Student = student;
                    newSchoolStudentEnrollment.School = existingSchool;
                    newSchoolStudentEnrollment.Status = EnrollmentStatus.Active;
                    newSchoolStudentEnrollment.Time = input.Time ?? DateTime.Now;

                    // Add and save the new admission asynchronously
                    await dbContext.SchoolStudentEnrollments.AddAsync(newSchoolStudentEnrollment);
                    await dbContext.SaveChangesAsync();

                    var newClassStudentEnrollment = new ClassStudentEnrollment
                    {
                        //rollNo needs to be implemented
                        Class = existingClass,
                        SchoolStudentEnrollment = newSchoolStudentEnrollment,
                        AcademicYear = existingAcademicYear,
                        Status = EnrollmentStatus.Active,
                        Time = input.Time ?? DateTime.Now,
                    };

                    await dbContext.ClassStudentEnrollments.AddAsync(newClassStudentEnrollment);
                    await dbContext.SaveChangesAsync();

                    // Commit the transaction asynchronously
                    await transaction.CommitAsync();
                    success = true;

                    if (schoolStudentEnrollmentRequest != null)
                    {
                        await sender.SendAsync(nameof(SchoolSubscription.SchoolStudentEnrollmentRequestProcessed), mapper.Map<SchoolStudentEnrollmentRequestModel>(schoolStudentEnrollmentRequest));
                    }
                    await sender.SendAsync(nameof(SchoolSubscription.SchoolStudentEnrollmentProcessed), mapper.Map<SchoolStudentEnrollmentModel>(newSchoolStudentEnrollment));
                    await sender.SendAsync(nameof(SchoolSubscription.ClassStudentEnrollmentProcessed), mapper.Map<ClassStudentEnrollment>(newClassStudentEnrollment));

                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    await transaction.RollbackAsync();

                    // Check if the exception is a concurrency-related issue
                    if (ex is DbUpdateConcurrencyException || ex is MySqlException)
                    {
                        // Log the attempt and retry if necessary
                        Console.WriteLine($"Attempt {attempt} failed. Retrying...");
                    }
                    else
                    {
                        // If it's a different kind of exception, rethrow it
                        throw;
                    }
                }
            }

            if (!success)
            {
                throw new OperationCanceledException($"Unable to create shool student admission after {maxRetries} attempts.");
            }
            return mapper.Map<SchoolStudentEnrollmentModel>(newSchoolStudentEnrollment);
        }

    }
}
