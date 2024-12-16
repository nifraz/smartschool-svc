using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotChocolate.Data;
using HotChocolate.Types;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Graphql.Inputs;
using SmartSchool.Graphql.Models;
using SmartSchool.Schema;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using System.Linq.Expressions;

namespace SmartSchool.Graphql.Queries
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
        public IQueryable<DivisionModel> GetDivisions(AppDbContext dbContext)
        {
            return dbContext.Divisions
                .Include(x => x.Zone.District.Province)
                .ProjectTo<DivisionModel>(mapper.ConfigurationProvider)
                ;
        }

        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<AcademicYearModel> GetAcademicYears(AppDbContext dbContext)
        {
            return dbContext.AcademicYears
                .ProjectTo<AcademicYearModel>(mapper.ConfigurationProvider)
                ;
        }

        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<SchoolModel> GetSchools(AppDbContext dbContext)
        {
            return dbContext.Schools
                .Include(x => x.Division)
                .ProjectTo<SchoolModel>(mapper.ConfigurationProvider)
                ;
        }

        public async Task<SchoolModel?> GetSchoolAsync(AppDbContext dbContext, long id)
        {
            var existingRecord = await dbContext.Schools
                .Include(x => x.Division)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingRecord == null)
            {
                return null;
            }

            var response = mapper.Map<SchoolModel>(existingRecord);

            var recentSchoolStudentEnrollmentRequests = await dbContext.SchoolStudentEnrollmentRequests
                .Where(x => x.SchoolId == existingRecord.Id)
                .Include(x => x.Person)
                .OrderByDescending(x => x.CreatedTime)
                .Take(10)
                .ToListAsync();
            response.RecentSchoolStudentEnrollmentRequests = mapper.Map<IEnumerable<SchoolStudentEnrollmentRequestModel>>(recentSchoolStudentEnrollmentRequests);

            var recentSchoolStudentEnrollments = await dbContext.SchoolStudentEnrollments
                .Where(x => x.SchoolId == existingRecord.Id)
                .Include(x => x.Student.Person)
                .OrderByDescending(x => x.CreatedTime)
                .Take(10)
                .ToListAsync();
            response.RecentSchoolStudentEnrollments = mapper.Map<IEnumerable<SchoolStudentEnrollmentModel>>(recentSchoolStudentEnrollments);

            var recentSchoolTeacherEnrollmentRequests = await dbContext.SchoolTeacherEnrollmentRequests
                .Where(x => x.SchoolId == existingRecord.Id)
                .Include(x => x.Person)
                .OrderByDescending(x => x.CreatedTime)
                .Take(10)
                .ToListAsync();
            response.RecentSchoolTeacherEnrollmentRequests = mapper.Map<IEnumerable<SchoolTeacherEnrollmentRequestModel>>(recentSchoolTeacherEnrollmentRequests);

            var recentSchoolTeacherEnrollments = await dbContext.SchoolTeacherEnrollments
                .Where(x => x.SchoolId == existingRecord.Id)
                .Include(x => x.Teacher.Person)
                .OrderByDescending(x => x.CreatedTime)
                .Take(10)
                .ToListAsync();
            response.RecentSchoolTeacherEnrollments = mapper.Map<IEnumerable<SchoolTeacherEnrollmentModel>>(recentSchoolTeacherEnrollments);

            var recentSchoolPrincipalEnrollments = await dbContext.SchoolPrincipalEnrollments
                .Where(x => x.SchoolId == existingRecord.Id)
                .Include(x => x.Principal.Person)
                .OrderByDescending(x => x.CreatedTime)
                .Take(10)
                .ToListAsync();
            response.RecentSchoolPrincipalEnrollments = mapper.Map<IEnumerable<SchoolPrincipalEnrollmentModel>>(recentSchoolPrincipalEnrollments);

            var allClasses = await dbContext.Classes
                .Where(x => x.SchoolId == existingRecord.Id)
                .Include(x => x.Language)
                .OrderByDescending(x => x.CreatedTime)
                .Take(10)
                .ToListAsync();
            response.AllClasses = mapper.Map<IEnumerable<ClassModel>>(allClasses);

            return response;
        }

        public async Task<SchoolReportModel> GetSchoolReportAsync(AppDbContext dbContext, SchoolReportInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var existingRecord = await dbContext.Schools
                .Include(x => x.Division.Zone.District.Province)
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            if (existingRecord == null)
            {
                return null;
            }

            var report = new SchoolReportModel
            {
                CurrentDate = DateTime.UtcNow,
                School = mapper.Map<SchoolModel>(existingRecord),
            };

            var principalEnrollment = await dbContext.SchoolPrincipalEnrollments
                .Include(x => x.Principal.Person)
                .Where(x => x.SchoolId == input.Id && x.Status == EnrollmentStatus.Active)
                .OrderByDescending(x => x.CreatedTime)
                .FirstOrDefaultAsync();

            if (principalEnrollment != null && principalEnrollment.Principal != null)
            {
                report.Principal = mapper.Map<PrincipalModel>(principalEnrollment.Principal);
            }

            report.NoOfStudentEnrollmentRequests = await dbContext.SchoolStudentEnrollmentRequests
                .CountAsync(x => x.SchoolId == input.Id &&
                    (!input.StartTime.HasValue || x.CreatedTime >= input.StartTime.Value) &&
                    (!input.EndTime.HasValue || x.CreatedTime <= input.EndTime.Value)
                );
            report.NoOfApprovedStudentEnrollmentRequests = await dbContext.SchoolStudentEnrollmentRequests
                .CountAsync(x => x.SchoolId == input.Id && x.Status == RequestStatus.Approved &&
                    (!input.StartTime.HasValue || x.CreatedTime >= input.StartTime.Value) &&
                    (!input.EndTime.HasValue || x.CreatedTime <= input.EndTime.Value)
                );
            report.NoOfRejectedStudentEnrollmentRequests = await dbContext.SchoolStudentEnrollmentRequests
                .CountAsync(x => x.SchoolId == input.Id && x.Status == RequestStatus.Rejected &&
                    (!input.StartTime.HasValue || x.CreatedTime >= input.StartTime.Value) &&
                    (!input.EndTime.HasValue || x.CreatedTime <= input.EndTime.Value)
                );
            report.NoOfCancelledStudentEnrollmentRequests = await dbContext.SchoolStudentEnrollmentRequests
                .CountAsync(x => x.SchoolId == input.Id && x.Status == RequestStatus.Cancelled &&
                    (!input.StartTime.HasValue || x.CreatedTime >= input.StartTime.Value) &&
                    (!input.EndTime.HasValue || x.CreatedTime <= input.EndTime.Value)
                );

            report.NoOfStudentEnrollments = await dbContext.SchoolStudentEnrollments
                .CountAsync(x => x.SchoolId == input.Id &&
                    (!input.StartTime.HasValue || x.CreatedTime >= input.StartTime.Value) &&
                    (!input.EndTime.HasValue || x.CreatedTime <= input.EndTime.Value)
                );
            report.NoOfActiveStudentEnrollments = await dbContext.SchoolStudentEnrollments
                .CountAsync(x => x.SchoolId == input.Id && x.Status == EnrollmentStatus.Active &&
                    (!input.StartTime.HasValue || x.CreatedTime >= input.StartTime.Value) &&
                    (!input.EndTime.HasValue || x.CreatedTime <= input.EndTime.Value)
                );
            report.NoOfLeftStudentEnrollments = await dbContext.SchoolStudentEnrollments
                .CountAsync(x => x.SchoolId == input.Id && x.Status == EnrollmentStatus.Left &&
                    (!input.StartTime.HasValue || x.CreatedTime >= input.StartTime.Value) &&
                    (!input.EndTime.HasValue || x.CreatedTime <= input.EndTime.Value)
                );
            report.NoOfCompletedStudentEnrollments = await dbContext.SchoolStudentEnrollments
                .CountAsync(x => x.SchoolId == input.Id && x.Status == EnrollmentStatus.Completed &&
                    (!input.StartTime.HasValue || x.CreatedTime >= input.StartTime.Value) &&
                    (!input.EndTime.HasValue || x.CreatedTime <= input.EndTime.Value)
                );
            report.NoOfCancelledStudentEnrollments = await dbContext.SchoolStudentEnrollments
                .CountAsync(x => x.SchoolId == input.Id && x.Status == EnrollmentStatus.Cancelled &&
                    (!input.StartTime.HasValue || x.CreatedTime >= input.StartTime.Value) &&
                    (!input.EndTime.HasValue || x.CreatedTime <= input.EndTime.Value)
                );

            report.NoOfTeacherEnrollments = await dbContext.SchoolTeacherEnrollments
                .CountAsync(x => x.SchoolId == input.Id &&
                    (!input.StartTime.HasValue || x.CreatedTime >= input.StartTime.Value) &&
                    (!input.EndTime.HasValue || x.CreatedTime <= input.EndTime.Value)
                );
            report.NoOfActiveTeacherEnrollments = await dbContext.SchoolTeacherEnrollments
                .CountAsync(x => x.SchoolId == input.Id && x.Status == EnrollmentStatus.Active &&
                    (!input.StartTime.HasValue || x.CreatedTime >= input.StartTime.Value) &&
                    (!input.EndTime.HasValue || x.CreatedTime <= input.EndTime.Value)
                );
            report.NoOfRetiredTeacherEnrollments = await dbContext.SchoolTeacherEnrollments
                .CountAsync(x => x.SchoolId == input.Id && x.Status == EnrollmentStatus.Retired &&
                    (!input.StartTime.HasValue || x.CreatedTime >= input.StartTime.Value) &&
                    (!input.EndTime.HasValue || x.CreatedTime <= input.EndTime.Value)
                );
            report.NoOfResignedTeacherEnrollments = await dbContext.SchoolTeacherEnrollments
                .CountAsync(x => x.SchoolId == input.Id && x.Status == EnrollmentStatus.Resigned &&
                    (!input.StartTime.HasValue || x.CreatedTime >= input.StartTime.Value) &&
                    (!input.EndTime.HasValue || x.CreatedTime <= input.EndTime.Value)
                );
            report.NoOfCancelledTeacherEnrollments = await dbContext.SchoolTeacherEnrollments
                .CountAsync(x => x.SchoolId == input.Id && x.Status == EnrollmentStatus.Cancelled &&
                    (!input.StartTime.HasValue || x.CreatedTime >= input.StartTime.Value) &&
                    (!input.EndTime.HasValue || x.CreatedTime <= input.EndTime.Value)
                );

            return report;
        }

        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<SchoolStudentEnrollmentRequestModel> GetSchoolStudentEnrollmentRequests(AppDbContext dbContext)
        {
            return dbContext.SchoolStudentEnrollmentRequests
                .Include(x => x.School)
                .Include(x => x.Person)
                .Include(x => x.AcademicYear)
                .Include(x => x.SchoolStudentEnrollment)
                .ProjectTo<SchoolStudentEnrollmentRequestModel>(mapper.ConfigurationProvider)
                ;
        }

        public async Task<SchoolStudentEnrollmentRequestModel?> GetSchoolStudentEnrollmentRequestAsync(AppDbContext dbContext, long id)
        {
            var existingRecord = await dbContext.SchoolStudentEnrollmentRequests
                .Include(x => x.School)
                .Include(x => x.Person)
                .Include(x => x.AcademicYear)
                .Include(x => x.SchoolStudentEnrollment)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingRecord == null)
            {
                return null;
            }

            var response = mapper.Map<SchoolStudentEnrollmentRequestModel>(existingRecord);

            return response;
        }

        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<SchoolStudentEnrollmentModel> GetSchoolStudentEnrollments(AppDbContext dbContext)
        {
            return dbContext.SchoolStudentEnrollments
                .Include(x => x.School)
                .Include(x => x.Student)
                .Include(x => x.SchoolStudentEnrollmentRequest)
                .ProjectTo<SchoolStudentEnrollmentModel>(mapper.ConfigurationProvider)
                ;
        }

        public async Task<SchoolStudentEnrollmentModel?> GetSchoolStudentEnrollmentAsync(AppDbContext dbContext, long id)
        {
            var existingRecord = await dbContext.SchoolStudentEnrollments
                .Include(x => x.School)
                .Include(x => x.Student.Person)
                .Include(x => x.SchoolStudentEnrollmentRequest)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingRecord == null)
            {
                return null;
            }

            var response = mapper.Map<SchoolStudentEnrollmentModel>(existingRecord);

            var recentClassStudentEnrollments = await dbContext.ClassStudentEnrollments
                .Where(x => x.SchoolStudentEnrollmentId == existingRecord.Id)
                .OrderByDescending(x => x.CreatedTime)
                .Take(10)
                .ToListAsync();
            response.RecentClassStudentEnrollments = mapper.Map<IEnumerable<ClassStudentEnrollmentModel>>(recentClassStudentEnrollments);

            return response;
        }

        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ClassModel> GetClasses(AppDbContext dbContext)
        {
            return dbContext.Classes
                .Include(x => x.School)
                .Include(x => x.Language)
                .ProjectTo<ClassModel>(mapper.ConfigurationProvider)
                ;
        }

        public async Task<ClassModel?> GetClassAsync(AppDbContext dbContext, long id)
        {
            var existingRecord = await dbContext.Classes
                .Include(x => x.School)
                .Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingRecord == null)
            {
                return null;
            }

            var response = mapper.Map<ClassModel>(existingRecord);

            var recentClassStudentEnrollments = await dbContext.ClassStudentEnrollments
                .Where(x => x.ClassId == existingRecord.Id)
                .Include(x => x.SchoolStudentEnrollment.Student.Person)
                .OrderByDescending(x => x.CreatedTime)
                .Take(10)
                .ToListAsync();
            response.RecentClassStudentEnrollments = mapper.Map<IEnumerable<ClassStudentEnrollmentModel>>(recentClassStudentEnrollments);

            return response;
        }

    }
}
