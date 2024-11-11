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
    public class TeachersQuery
    {
        private readonly IMapper mapper;

        public TeachersQuery(
            IMapper mapper
        )
        {
            this.mapper = mapper;
        }

        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<TeacherModel> GetTeachers(AppDbContext dbContext)
        {
            return dbContext.Teachers
                .Include(x => x.Person)
                .ProjectTo<TeacherModel>(mapper.ConfigurationProvider)
                ;
        }

        public async Task<TeacherModel?> GetTeacherAsync(AppDbContext dbContext, long id)
        {
            var existingRecord = await dbContext.Teachers
                .Include(x => x.Person)
                .Include(x => x.SchoolTeacherEnrollments)
                .ThenInclude(x => x.School)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingRecord == null)
            {
                return null;
            }

            var response = mapper.Map<TeacherModel>(existingRecord);

            response.SchoolTeacherEnrollments = mapper.Map<IEnumerable<SchoolTeacherEnrollmentModel>>(existingRecord.SchoolTeacherEnrollments);

            return response;
        }

    }
}
