using HotChocolate;
using HotChocolate.Types;
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
