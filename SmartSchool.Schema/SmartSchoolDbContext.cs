using Microsoft.EntityFrameworkCore;
using SmartSchool.Schema.Configurations;
using SmartSchool.Schema.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema
{
    public class SmartSchoolDbContext : DbContext
    {
        //public DbSet<School> Schools { get; set; }
        //public DbSet<Class> Classes { get; set; }
        //public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Guardian> Guardians { get; set; }
        //public DbSet<Qualification> Qualifications { get; set; }
        //public DbSet<Admission> Admissions { get; set; }
        //public DbSet<Leave> Leaves { get; set; }
        //public DbSet<Teach> Teaches { get; set; }
        //public DbSet<PersonQualification> PersonQualifications { get; set; } //review
        //public DbSet<StudentGuardian> StudentGuardians { get; set; }

        /// <summary>
        /// dotnet ef migrations add InitialCreate --project SmartSchool.Schema --startup-project SmartSchool.Api
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
                if (entityEntry.Entity is Record record)
                {
                    switch (entityEntry.State)
                    {
                        case EntityState.Detached:
                            break;
                        case EntityState.Unchanged:
                            break;
                        case EntityState.Deleted:
                            break;
                        case EntityState.Modified:
                            record.LastModifiedBy = 1; //change
                            record.LastModifiedOn = DateTime.UtcNow;
                            break;
                        case EntityState.Added:
                            record.Guid = Guid.NewGuid();
                            record.CreatedBy = 1; //change
                            record.CreatedOn = DateTime.UtcNow;
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
            //modelBuilder.Entity<Person>().UseTptMappingStrategy();

            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            //base.OnModelCreating(modelBuilder);

            // Relationships
            //modelBuilder.Entity<Person>()
            //    .HasOne(x => x.Student)
            //    .WithOne(y => y.Person)
            //    .HasForeignKey<Student>(x => x.PersonId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Admission>()
            //    .HasOne(a => a.Student)
            //    .WithMany(s => s.Admissions)
            //    .HasForeignKey(a => a.StudentId);

            //modelBuilder.Entity<Admission>()
            //    .HasOne(a => a.School)
            //    .WithMany(s => s.Admissions)
            //    .HasForeignKey(a => a.SchoolId);

            //modelBuilder.Entity<Admission>()
            //    .HasOne(a => a.Class)
            //    .WithMany(c => c.Admissions)
            //    .HasForeignKey(a => a.ClassId);

            //modelBuilder.Entity<Leave>()
            //    .HasOne(l => l.Student)
            //    .WithMany(s => s.Leaves)
            //    .HasForeignKey(l => l.StudentId);

            //modelBuilder.Entity<Leave>()
            //    .HasOne(l => l.School)
            //    .WithMany(s => s.Leaves)
            //    .HasForeignKey(l => l.SchoolId);

            //modelBuilder.Entity<Teach>()
            //    .HasOne(t => t.Teacher)
            //    .WithMany(t => t.Teaches)
            //    .HasForeignKey(t => t.TeacherId);

            //modelBuilder.Entity<Teach>()
            //    .HasOne(t => t.Class)
            //    .WithMany(c => c.Teaches)
            //    .HasForeignKey(t => t.ClassId);

            //modelBuilder.Entity<TeacherQualification>()
            //    .HasOne(tq => tq.Teacher)
            //    .WithMany(t => t.TeacherQualifications)
            //    .HasForeignKey(tq => tq.TeacherId);

            //modelBuilder.Entity<TeacherQualification>()
            //    .HasOne(tq => tq.Qualification)
            //    .WithMany(q => q.TeacherQualifications)
            //    .HasForeignKey(tq => tq.QualificationId);

            //modelBuilder.Entity<StudentGuardian>()
            //    .HasOne(sg => sg.Student)
            //    .WithMany(s => s.StudentGuardians)
            //    .HasForeignKey(sg => sg.StudentId);

            //modelBuilder.Entity<StudentGuardian>()
            //    .HasOne(sg => sg.Guardian)
            //    .WithMany(g => g.StudentGuardians)
            //    .HasForeignKey(sg => sg.GuardianId);

            //modelBuilder.Entity<Relationship>()
            //.HasOne(r => r.ParentPerson)
            //.WithMany(p => p.Relationships)
            //.HasForeignKey(r => r.ParentPersonID)
            //.OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Relationship>()
            //    .HasOne(r => r.ChildPerson)
            //    .WithMany()
            //    .HasForeignKey(r => r.ChildPersonID)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
