using AutoMapper;
using HotChocolate.Subscriptions;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using SmartSchool.Schema.Inputs;
using SmartSchool.Schema.Types;
using HotChocolate.Execution.Processing;
using SmartSchool.Schema.Subscriptions;

namespace SmartSchool.Schema.Mutations
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

        public async Task<SchoolStudentEnrollmentRequestModel> CreateSchoolStudentEnrollmentRequestAsync(AppDbContext dbContext, SchoolStudentEnrollmentRequestInput input)
        {
            var newRecord = mapper.Map<SchoolStudentEnrollmentRequest>(input);
            newRecord.Status = RequestStatus.Pending;
            dbContext.SchoolStudentEnrollmentRequests.Add(newRecord);
            await dbContext.SaveChangesAsync();

            return mapper.Map<SchoolStudentEnrollmentRequestModel>(newRecord);
        }

        public async Task<SchoolStudentEnrollmentRequestModel> UpdateSchoolStudentEnrollmentRequestAsync(AppDbContext dbContext, long id, SchoolStudentEnrollmentRequestInput input)
        {
            var existingRecord = await dbContext.SchoolStudentEnrollmentRequests.FindAsync(id) ?? throw new KeyNotFoundException($"No matching record found (id={id})");

            mapper.Map(input, existingRecord);
            await dbContext.SaveChangesAsync();

            return mapper.Map<SchoolStudentEnrollmentRequestModel>(existingRecord);
        }

        public async Task<SchoolStudentEnrollmentRequestModel> UpdateSchoolStudentEnrollmentRequestStatusAsync(AppDbContext dbContext, long id, SchoolStudentEnrollmentRequestStatusUpdateInput input)
        {
            var existingRecord = await dbContext.SchoolStudentEnrollmentRequests.FindAsync(id) ?? throw new KeyNotFoundException($"No matching record found (id={id})");

            existingRecord.Status = input.Status;
            existingRecord.Reason = input.Reason;
            await dbContext.SaveChangesAsync();

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

                    await sender.SendAsync(nameof(SchoolSubscription.SchoolStudentEnrollmentCreated), mapper.Map<SchoolStudentEnrollmentModel>(newSchoolStudentEnrollment));

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
                throw new Exception($"Unable to create shool admission after {maxRetries} attempts.");
            }
            return mapper.Map<SchoolStudentEnrollmentModel>(newSchoolStudentEnrollment);
        }

    }
}
