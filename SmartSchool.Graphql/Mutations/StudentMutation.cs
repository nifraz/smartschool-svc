using AutoMapper;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using SmartSchool.Graphql.Inputs;
using SmartSchool.Graphql.Models;
using SmartSchool.Schema;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class StudentMutation
    {
        //private readonly IDbContextFactory<SmartSchoolDbContext> dbContextFactory;
        private readonly IMapper mapper;

        public StudentMutation(
            //IDbContextFactory<SmartSchoolDbContext> dbContextFactory,
            IMapper mapper
        )
        {
            //this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        public async Task<StudentModel> CreateStudentAsync(AppDbContext dbContext, StudentInput input)
        {
            //using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var newRecord = mapper.Map<Student>(input);
            //newRecord.DateOfBirth = DateTime.SpecifyKind(newRecord.DateOfBirth, DateTimeKind.Utc); //need fix

            dbContext.Students.Add(newRecord);
            await dbContext.SaveChangesAsync();

            return mapper.Map<StudentModel>(newRecord);
        }

        public async Task<StudentModel> UpdateStudentAsync(AppDbContext dbContext, long id, StudentInput input)
        {
            var existingRecord = await dbContext.Students.FindAsync(id) ?? throw new KeyNotFoundException($"No matching record found (id={id})");
            mapper.Map(input, existingRecord);

            await dbContext.SaveChangesAsync();

            return mapper.Map<StudentModel>(existingRecord);
        }

        public async Task CreateSchoolAdmissionAsync(AppDbContext dbContext, long schoolId, SchoolStudentEnrollment newAdmission)
        {
            bool success = false;
            const int maxRetries = 3;
            int attempt = 0;

            while (!success && attempt < maxRetries)
            {
                attempt++;

                using var transaction = await dbContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
                try
                {
                    // Get the latest AdmissionNo for the specified SchoolId within the transaction
                    var latestSchoolAdmission = await dbContext.SchoolStudentEnrollments
                        .Where(a => a.SchoolId == schoolId)
                        .OrderByDescending(a => a.No)
                        .FirstOrDefaultAsync();

                    // Determine the new AdmissionCode
                    int newAdmissionNo = latestSchoolAdmission != null ? latestSchoolAdmission.No + 1 : 1;

                    // Assign the new AdmissionCode to the Admission entity
                    newAdmission.No = newAdmissionNo/*.ToString("D5")*/; // E.g., "00001", "00002", etc.
                    newAdmission.SchoolId = schoolId;
                    newAdmission.Status = EnrollmentStatus.Active;

                    // Add and save the new admission asynchronously
                    await dbContext.SchoolStudentEnrollments.AddAsync(newAdmission);
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
        }

    }
}
