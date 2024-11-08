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
    public class SchoolsQuery
    {
        private readonly IMapper mapper;

        public SchoolsQuery(
            IMapper mapper
        )
        {
            this.mapper = mapper;
        }

        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<SchoolModel> GetSchools(SmartSchoolDbContext dbContext)
        {
            return dbContext.Schools
                .Include(x => x.SchoolStudentEnrollmentRequests)
                .Include(x => x.SchoolStudentEnrollments)
                .Include(x => x.SchoolTeacherEnrollmentRequests)
                .Include(x => x.SchoolTeacherEnrollments)
                .Include(x => x.SchoolPrincipalEnrollments)
                .Include(x => x.Classes)
                .ThenInclude(x => x.Language)
                .ProjectTo<SchoolModel>(mapper.ConfigurationProvider)
                ;
        }

        public async Task<SchoolModel?> GetSchoolAsync(SmartSchoolDbContext dbContext, long id)
        {
            var existingRecord = await dbContext.Schools
                .Include(x => x.SchoolStudentEnrollmentRequests)
                .Include(x => x.SchoolStudentEnrollments)
                .Include(x => x.SchoolTeacherEnrollmentRequests)
                .Include(x => x.SchoolTeacherEnrollments)
                .Include(x => x.SchoolPrincipalEnrollments)
                .Include(x => x.Classes)
                .ThenInclude(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingRecord == null)
            {
                return null;
            }

            var response = mapper.Map<SchoolModel>(existingRecord);

            response.SchoolStudentEnrollmentRequests = mapper.Map<IEnumerable<SchoolStudentEnrollmentRequestModel>>(existingRecord.SchoolStudentEnrollmentRequests);
            response.SchoolStudentEnrollments = mapper.Map<IEnumerable<SchoolStudentEnrollmentModel>>(existingRecord.SchoolStudentEnrollments);
            response.SchoolTeacherEnrollmentRequests = mapper.Map<IEnumerable<SchoolTeacherEnrollmentRequestModel>>(existingRecord.SchoolTeacherEnrollmentRequests);
            response.SchoolTeacherEnrollments = mapper.Map<IEnumerable<SchoolTeacherEnrollmentModel>>(existingRecord.SchoolTeacherEnrollments);
            response.SchoolPrincipalEnrollments = mapper.Map<IEnumerable<SchoolPrincipalEnrollmentModel>>(existingRecord.SchoolPrincipalEnrollments);
            response.Classes = mapper.Map<IEnumerable<ClassModel>>(existingRecord.Classes);

            return response;
        }

    }
}
