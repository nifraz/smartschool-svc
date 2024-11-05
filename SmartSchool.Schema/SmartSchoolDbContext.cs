using Microsoft.EntityFrameworkCore;
using SmartSchool.Schema.Configurations;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema
{
    public class SmartSchoolDbContext : DbContext
    {
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<School> Schools { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }

        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Class> Classes { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonRelationship> PersonRelationships { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Principal> Principals { get; set; }

        public DbSet<SchoolStudentAdmissionRequest> SchoolStudentAdmissionRequests { get; set; }
        public DbSet<SchoolStudentAdmission> SchoolStudentAdmissions { get; set; }
        public DbSet<ClassStudentAssignment> ClassStudentAssignments { get; set; }

        public DbSet<SchoolTeacherEnrollmentRequest> SchoolTeacherEnrollmentRequests { get; set; }
        public DbSet<SchoolTeacherEnrollment> SchoolTeacherEnrollments { get; set; }
        public DbSet<ClassTeacherAssignment> ClassTeacherAssignments { get; set; }

        public DbSet<SchoolPrincipalEnrollment> SchoolPrincipalEnrollments { get; set; }

        public DbSet<PersonQualification> PersonQualifications { get; set; }

        /// <summary>
        /// dotnet ef migrations add CreateInitialSchema --project SmartSchool.Schema --startup-project SmartSchool.Api
        /// dotnet ef database update --project SmartSchool.Schema --startup-project SmartSchool.Api
        /// </summary>
        /// <param name="options"></param>
        public SmartSchoolDbContext(DbContextOptions<SmartSchoolDbContext> options) : base(options)
        {
            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entityEntry in ChangeTracker.Entries()) // Iterate all made changes
            {
                if (entityEntry.Entity is AbstractRecord record)
                {
                    switch (entityEntry.State)
                    {
                        case EntityState.Detached:
                            break;
                        case EntityState.Unchanged:
                            break;
                        case EntityState.Deleted:
                            record.DeletedUserId = 1; // Set the user ID who deleted the record
                            record.DeletedTime = DateTime.Now; // Set the deletion time
                            entityEntry.State = EntityState.Modified; // Change state to Modified to perform a soft delete
                            break;
                        case EntityState.Modified:
                            record.LastModifiedUserId = 1; // Set the user ID who modified the record
                            record.LastModifiedTime = DateTime.Now; // Set the modification time
                            break;
                        case EntityState.Added:
                            record.CreatedUserId = 1; // Set the user ID who created the record
                            record.CreatedTime = DateTime.Now; // Set the creation time
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            // Apply global query filter for all entities that inherit from AbstractRecord
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(AbstractRecord).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(CreateSoftDeleteFilter(entityType.ClrType));
                }
            }

            modelBuilder.Seed();
        }

        private static LambdaExpression CreateSoftDeleteFilter(Type entityType)
        {
            var parameter = Expression.Parameter(entityType, "e");
            var property = Expression.Property(parameter, nameof(AbstractRecord.DeletedTime));
            var nullConstant = Expression.Constant(null, typeof(DateTime?));
            var comparison = Expression.Equal(property, nullConstant);

            return Expression.Lambda(comparison, parameter);
        }
    }
}
