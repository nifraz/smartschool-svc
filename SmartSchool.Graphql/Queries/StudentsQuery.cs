using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Graphql.Models;
using SmartSchool.Schema;

namespace SmartSchool.Graphql.Queries
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
        [UseFiltering]
        [UseSorting]
        public IQueryable<StudentModel> GetStudents(AppDbContext dbContext)
        {
            return dbContext.Students
                .Include(x => x.Person)
                .ProjectTo<StudentModel>(mapper.ConfigurationProvider)
                ;
        }

        public async Task<StudentModel?> GetStudentAsync(AppDbContext dbContext, long id)
        {
            var existingRecord = await dbContext.Students
                .Include(x => x.Person)
                .Include(x => x.SchoolStudentEnrollments)
                .ThenInclude(x => x.School)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingRecord == null)
            {
                return null;
            }

            var response = mapper.Map<StudentModel>(existingRecord);

            response.SchoolStudentEnrollments = mapper.Map<IEnumerable<SchoolStudentEnrollmentModel>>(existingRecord.SchoolStudentEnrollments);

            return response;
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
