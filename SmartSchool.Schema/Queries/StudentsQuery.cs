using AutoMapper;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Filters;
using SmartSchool.Schema.Sorters;
using SmartSchool.Schema.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class StudentsQuery
    {
        private readonly IMapper mapper;

        public StudentsQuery(
            IMapper mapper
        )
        {
            this.mapper = mapper;
        }

        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering(typeof(StudentFilter))]
        [UseSorting(typeof(StudentSort))]
        public IQueryable<StudentType> GetStudents(SmartSchoolDbContext dbContext)
        {
            return dbContext.Students
                //.Include(x => x.Person)
                .Select(x => new StudentType
                {
                    Id = x.Id,
                    Guid = x.Guid,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn,
                    LastModifiedBy = x.LastModifiedBy,
                    LastModifiedOn = x.LastModifiedOn,

                    FullName = x.FullName,
                    ShortName = x.ShortName,
                    Nickname = x.Nickname,
                    DateOfBirth = x.DateOfBirth,
                    BcNo = x.BcNo,
                    Sex = x.Sex,
                    NicNo = x.NicNo,
                    ContactNo = x.ContactNo,
                    Email = x.Email,
                    Address = x.Address,

                    //Person = new PersonType
                    //{
                    //    Id = x.Person.Id,
                    //    FullName = x.Person.FullName,
                    //    Nickname = x.Person.Nickname,
                    //    DateOfBirth = x.Person.DateOfBirth,
                    //},
                    //StudentId = x.StudentId,
                    //FullName = x.FullName,
                    //Nickname = x.Nickname,
                    //DateOfBirth = x.DateOfBirth,
                    //MobileNo = x.MobileNo,
                }
            );
        }

        public async Task<StudentType?> GetStudentAsync(SmartSchoolDbContext dbContext, long id)
        {
            var existingRecord = await dbContext.Students
                .FindAsync(id);

            if (existingRecord == null)
            {
                return null;
            }

            return mapper.Map<StudentType>(existingRecord);
        }

        //[UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        //[UseProjection]
        //[UseFiltering(typeof(CourseFilterType))]
        //[UseSorting(typeof(CourseSortType))]
        //public IQueryable<CourseType> GetCourses([Service(ServiceKind.Resolver)] SchoolDbContext context) //ServiceKind.Resolver needs thorough testing with multiple resolvers in parallel
        //{
        //    return context.Courses
        //        .Select(x => new CourseType
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            Subject = x.Subject,
        //            InstructorId = x.InstructorId,
        //            CreatorId = x.CreatorId
        //        }
        //    );
        //}
    }
}
