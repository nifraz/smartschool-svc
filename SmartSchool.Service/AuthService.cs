using AutoMapper;
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
        private readonly IDbContextFactory<SmartSchoolDbContext> dbContextFactory;
        private readonly IMapper mapper;
        private readonly AuthSettings authSettings;

        public AuthService(
            IDbContextFactory<SmartSchoolDbContext> dbContextFactory,
            IMapper mapper,
            IOptions<AuthSettings> authSettings
            )
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
            this.authSettings = authSettings.Value;
        }
        public async Task<AuthenticateResponse?> RegisterAsync(UserRegisterRequest model)
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
                user.PersonId = person.Id;
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();

                //_ = Task.Run(() => notificationService.SendRegistrationCompletedEmailAsync(model));

                //await notificationService.SendRegistrationCompletedSmsAsync(model);

                var token = await GenerateJwtToken(user);

                await dbContext.Database.CommitTransactionAsync();
                return new AuthenticateResponse(user, token);
            }
            catch (Exception)
            {
                await dbContext.Database.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<AuthenticateResponse?> LoginAsync(LoginRequest model)
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
            var token = await GenerateJwtToken(user);
            return new AuthenticateResponse(user, token);
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

        private async Task<string> GenerateJwtToken(User user)
        {
            //Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {

                var key = Encoding.ASCII.GetBytes(authSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }
    }
}
