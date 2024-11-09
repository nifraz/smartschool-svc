using AutoMapper;
using HotChocolate.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using SmartSchool.Schema.Inputs;
using SmartSchool.Schema.Types;

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

        public async Task<SchoolStudentEnrollmentRequestModel> UpdateSchoolStudentEnrollmentRequestStatusAsync(AppDbContext dbContext, long id, RequestStatus input)
        {
            var existingRecord = await dbContext.SchoolStudentEnrollmentRequests.FindAsync(id) ?? throw new KeyNotFoundException($"No matching record found (id={id})");

            existingRecord.Status = input;
            await dbContext.SaveChangesAsync();

            return mapper.Map<SchoolStudentEnrollmentRequestModel>(existingRecord);
        }

        public async Task<SchoolStudentEnrollmentModel> CreateSchoolStudentEnrollmentAsync(AppDbContext dbContext, SchoolStudentEnrollmentInput input)
        {
            var existingPerson = await dbContext.Persons
                .Include(x => x.Student)
                .FirstOrDefaultAsync(x => x.Id == input.PersonId) ?? throw new KeyNotFoundException($"No matching record found (id={input.PersonId})");

            var newRecord = mapper.Map<SchoolStudentEnrollment>(input);

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
                    // Get the latest AdmissionNo for the specified SchoolId within the transaction
                    var latestSchoolRecord = await dbContext.SchoolStudentEnrollments
                        .Where(a => a.SchoolId == newRecord.SchoolId)
                        .OrderByDescending(a => a.No)
                        .FirstOrDefaultAsync();

                    // Determine the new AdmissionCode
                    int newNo = latestSchoolRecord != null ? latestSchoolRecord.No + 1 : 1;

                    // Assign the new AdmissionCode to the Admission entity
                    newRecord.No = newNo/*.ToString("D5")*/; // E.g., "00001", "00002", etc.
                    newRecord.Student = student;
                    newRecord.Status = EnrollmentStatus.Active;

                    // Add and save the new admission asynchronously
                    await dbContext.SchoolStudentEnrollments.AddAsync(newRecord);
                    await dbContext.SaveChangesAsync();

                    // Commit the transaction asynchronously
                    await transaction.CommitAsync();
                    success = true;
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
            return mapper.Map<SchoolStudentEnrollmentModel>(newRecord);
        }

    }
}
