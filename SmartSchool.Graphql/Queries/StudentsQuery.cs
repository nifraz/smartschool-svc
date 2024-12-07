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
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingRecord == null)
            {
                return null;
            }

            var response = mapper.Map<StudentModel>(existingRecord);

            var recentSchoolStudentEnrollments = await dbContext.SchoolStudentEnrollments
                .Where(x => x.StudentId == existingRecord.Id)
                .Include(x => x.School)
                .OrderByDescending(x => x.CreatedTime)
                .Take(10)
                .ToListAsync();
            response.RecentSchoolStudentEnrollments = mapper.Map<IEnumerable<SchoolStudentEnrollmentModel>>(recentSchoolStudentEnrollments);

            return response;
        }
    }
}
