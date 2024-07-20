using AutoMapper;
using HotChocolate;
using HotChocolate.Types;
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
                .Select(x => new StudentType
                {
                    Id = x.Id,
                    StudentId = x.StudentId,
                    FullName = x.FullName,
                    NickName = x.NickName,
                    DateOfBirth = x.DateOfBirth,
                    MobileNo = x.MobileNo,
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
