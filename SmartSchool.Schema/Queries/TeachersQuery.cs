using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public IQueryable<TeacherModel> GetTeachers(SmartSchoolDbContext dbContext)
        {
            return dbContext.Teachers
                .Include(x => x.Person)
                .ProjectTo<TeacherModel>(mapper.ConfigurationProvider)
                ;
        }

        public async Task<TeacherModel?> GetTeacherAsync(SmartSchoolDbContext dbContext, long id)
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
