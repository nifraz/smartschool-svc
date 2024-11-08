using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartSchool.Schema;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using SmartSchool.Schema.Models;
using SmartSchool.Schema.Models.Settings;
using SmartSchool.Utility.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Service
{
    public class AuthService : IAuthService
    {
        private readonly IDbContextFactory<AppDbContext> dbContextFactory;
        private readonly IMapper mapper;
        private readonly AuthSettings authSettings;

        public AuthService(
            IDbContextFactory<AppDbContext> dbContextFactory,
            IMapper mapper,
            IOptions<AuthSettings> authSettings
            )
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
            this.authSettings = authSettings.Value;
        }
        public async Task<UserResponse?> RegisterAsync(UserRegisterRequest model)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            try
            {
                await dbContext.Database.BeginTransactionAsync();

                var person = mapper.Map<Person>(model);

                await dbContext.Persons.AddAsync(person);
                await dbContext.SaveChangesAsync();

                var user = mapper.Map<User>(model);
                user.Password = PasswordHasher.HashPassword(model.Password);
                user.Person = person;
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();

                //_ = Task.Run(() => notificationService.SendRegistrationCompletedEmailAsync(model));

                //await notificationService.SendRegistrationCompletedSmsAsync(model);
                await dbContext.Database.CommitTransactionAsync();
                return mapper.Map<UserResponse>(user);
            }
            catch (Exception)
            {
                await dbContext.Database.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<AuthenticateResponse?> LoginAsync(UserLoginRequest model)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            var user = await dbContext.Users
                .Include(x => x.Person)
                .FirstOrDefaultAsync(x => x.Person.Email == model.Email
                    || x.Person.MobileNo == model.MobileNo);

            // return null if user not found or not registered
            if (user == null)
            {
                return null;
            }

            if (!PasswordHasher.VerifyPassword(user.Password, model.Password))
            {
                return null;
            }

            // authentication successful so generate jwt token
            var jwtData = await GenerateJwtToken(user);
            return new AuthenticateResponse(user, jwtData);
        }

        public async Task<UserResponse?> GetUserAsync(long id)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var user = await dbContext.Users
                .AsNoTracking()
                .Include(x => x.Person)
                .FirstOrDefaultAsync(x => id.Equals(x.Id));

            if (user == null)
            {
                return null;
            }

            var person = await dbContext.Persons
                .AsNoTracking()
                .Include(x => x.Student)
                .Include(x => x.Teacher)
                .Include(x => x.Principal)
                .FirstOrDefaultAsync(x => x.Id == user.PersonId);

            if (person == null)
            {
                return null;
            }

            user.Person = person;
            var authenticateResponse = mapper.Map<UserResponse>(user);

            authenticateResponse.StudentId = person.Student?.Id;
            authenticateResponse.TeacherId = person.Teacher?.Id;
            authenticateResponse.PrincipalId = person.Principal?.Id;

            var latestSchoolStudentAdmissions = await dbContext.SchoolStudentEnrollments
                .AsNoTracking()
                .Where(x => person.Student != null && person.Student.Id > 0)
                .OrderByDescending(x => x.Time)
                .Select(x => new { x.SchoolId, x.Time, x.Status })
                .Take(1)
                .ToListAsync();

            var latestSchoolTeacherEnrollments = await dbContext.SchoolTeacherEnrollments
                .AsNoTracking()
                .Where(x => person.Teacher != null && person.Teacher.Id > 0)
                .OrderByDescending(x => x.Time)
                .Select(x => new { x.SchoolId, x.Time, x.Status })
                .Take(1)
                .ToListAsync();

            var latestSchoolPrincipalEnrollments = await dbContext.SchoolPrincipalEnrollments
                .AsNoTracking()
                .Where(x => person.Principal != null && person.Principal.Id > 0)
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

            authenticateResponse.SchoolId = latestSchool?.SchoolId;

            return authenticateResponse;
        }

        public async Task<bool> IsEmailRegistered(string email)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var existingRecord = await dbContext.Users
                .Include(x => x.Person)
                .Select(x => x.Person.Email)
                .FirstOrDefaultAsync(x => email.Equals(x));

            return existingRecord != null;
        }

        public async Task<bool> IsEmailRegistered(int id, string email)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            return await dbContext.Users
                .Include(x => x.Person)
                .AnyAsync(x => x.Id != id && x.Person.Email == email);
        }

        public async Task<bool> IsMobileNoRegistered(string mobileNo)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var existingRecord = await dbContext.Users
                .Include(x => x.Person)
                .Select(x => x.Person.MobileNo)
                .FirstOrDefaultAsync(x => mobileNo.Equals(x));

            return existingRecord != null;
        }

        public async Task<bool> IsMobileNoRegistered(int id, string mobileNo)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            return await dbContext.Users
                .AnyAsync(x => x.Id != id && x.Person.MobileNo == mobileNo);
        }

        private async Task<JwtData> GenerateJwtToken(User user)
        {
            //Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var expires = DateTime.UtcNow.AddDays(7);
            var token = await Task.Run(() =>
            {

                var key = Encoding.ASCII.GetBytes(authSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                    Expires = expires,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return new JwtData(tokenHandler.WriteToken(token), expires);
        }
    }
}
