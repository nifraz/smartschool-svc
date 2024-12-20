﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Graphql.Models;
using SmartSchool.Schema;
using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class UsersQuery
    {
        private readonly IMapper mapper;

        public UsersQuery(
            IMapper mapper
        )
        {
            this.mapper = mapper;
        }

        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<UserModel> GetUsers(AppDbContext dbContext)
        {
            return dbContext.Users
                .Include(x => x.Person)
                .ProjectTo<UserModel>(mapper.ConfigurationProvider)
                ;
        }

        public async Task<UserModel?> GetUserAsync(AppDbContext dbContext, long id)
        {
            var existingRecord = await dbContext.Users
                .Include(x => x.Person.Student)
                .Include(x => x.Person.Teacher)
                .Include(x => x.Person.Principal)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingRecord == null)
            {
                return null;
            }

            var response = mapper.Map<UserModel>(existingRecord);

            var recentCreatedSchoolStudentEnrollmentRequests = await dbContext.SchoolStudentEnrollmentRequests
                .Where(x => x.CreatedUserId == existingRecord.Id)
                .Include(x => x.School)
                .Include(x => x.Person)
                .OrderByDescending(x => x.CreatedTime)
                .Take(10)
                .ToListAsync();
            response.RecentCreatedSchoolStudentEnrollmentRequests = mapper.Map<IEnumerable<SchoolStudentEnrollmentRequestModel>>(recentCreatedSchoolStudentEnrollmentRequests);

            var recentCreatedPersons = await dbContext.Persons
                .Where(x => x.CreatedUserId == existingRecord.Id)
                .OrderByDescending(x => x.CreatedTime)
                .Take(10)
                .ToListAsync();
            response.RecentCreatedPersons = mapper.Map<IEnumerable<PersonModel>>(recentCreatedPersons);

            response.StudentId = existingRecord.Person?.Student?.Id;
            response.TeacherId = existingRecord.Person?.Teacher?.Id;
            response.PrincipalId = existingRecord.Person?.Principal?.Id;

            var latestSchoolStudentAdmissions = await dbContext.SchoolStudentEnrollments
                .AsNoTracking()
                .Where(x => existingRecord.Person != null && existingRecord.Person.Student != null && existingRecord.Person.Student.Id > 0)
                .OrderByDescending(x => x.Time)
                .Select(x => new { x.SchoolId, x.Time, x.Status })
                .Take(1)
                .ToListAsync();

            var latestSchoolTeacherEnrollments = await dbContext.SchoolTeacherEnrollments
                .AsNoTracking()
                .Where(x => existingRecord.Person != null && existingRecord.Person.Teacher != null && existingRecord.Person.Teacher.Id > 0)
                .OrderByDescending(x => x.Time)
                .Select(x => new { x.SchoolId, x.Time, x.Status })
                .Take(1)
                .ToListAsync();

            var latestSchoolPrincipalEnrollments = await dbContext.SchoolPrincipalEnrollments
                .AsNoTracking()
                .Where(x => existingRecord.Person != null && existingRecord.Person.Principal != null && existingRecord.Person.Principal.Id > 0)
                .OrderByDescending(x => x.Time)
                .Select(x => new { x.SchoolId, x.Time, x.Status })
                .Take(1)
                .ToListAsync();

            var latestSchool = latestSchoolStudentAdmissions
                .Concat(latestSchoolTeacherEnrollments)
                .Concat(latestSchoolPrincipalEnrollments)
                .Where(x => x.Status == EnrollmentStatus.Active)
                .OrderByDescending(x => x.Time)
            .FirstOrDefault();

            response.CurrentSchoolId = latestSchool?.SchoolId;

            return response;
        }

    }
}
