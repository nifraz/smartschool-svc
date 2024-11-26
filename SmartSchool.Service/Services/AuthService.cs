using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartSchool.Schema;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using SmartSchool.Service.Helpers;
using SmartSchool.Service.Models;
using SmartSchool.Service.Models.Settings;
using SmartSchool.Utility.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SmartSchool.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IDbContextFactory<AppDbContext> dbContextFactory;
        private readonly IMapper mapper;
        private readonly INotificationService notificationService;
        private readonly AuthSettings authSettings;

        public AuthService(
            IDbContextFactory<AppDbContext> dbContextFactory,
            IMapper mapper,
            IOptions<AuthSettings> authSettings,
            INotificationService notificationService
            )
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
            this.notificationService = notificationService;
            this.authSettings = authSettings.Value;
        }
        public async Task<UserResponse?> RegisterAsync(RegisterRequest model)
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
                user.IsEmailVerified = false;
                user.EmailOtp = OtpGenerator.GenerateOtp();
                user.EmailToken = Guid.NewGuid().ToString();
                user.IsMobileNoVerified = false;
                user.MobileNoOtp = OtpGenerator.GenerateOtp();
                user.Person = person;

                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();

                //_ = Task.Run(() => notificationService.SendRegistrationCompletedEmailAsync(user));
                await notificationService.SendRegistrationCompletedEmailAsync(user);

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

        public async Task<UserResponse> VerifyAsync(VerifyRequest model)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var existingUser = await dbContext.Users
                .Include(x => x.Person)
                .FirstOrDefaultAsync(x => x.Person.Email == model.Email) ?? throw new KeyNotFoundException($"No matching User found (email={model.Email})");

            if (string.IsNullOrWhiteSpace(model.EmailOtp) && string.IsNullOrWhiteSpace(model.EmailToken))
            {
                throw new UnauthorizedAccessException($"OTP or Token is required.");
            }

            if (!string.IsNullOrWhiteSpace(model.EmailOtp) && existingUser.EmailOtp != model.EmailOtp)
            {
                throw new UnauthorizedAccessException($"The verification code entered is incorrect.");
            }

            if (!string.IsNullOrWhiteSpace(model.EmailToken) && existingUser.EmailToken != model.EmailToken)
            {
                throw new UnauthorizedAccessException($"The verification token is invalid.");
            }

            existingUser.IsEmailVerified = true;
            await dbContext.SaveChangesAsync();

            return mapper.Map<UserResponse>(existingUser);
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
            var jwtData = await GenerateJwtToken(user);
            return new AuthenticateResponse(user, jwtData);
        }

        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var existingRecord = await dbContext.Persons
                .Select(x => x.Email)
                .FirstOrDefaultAsync(x => email.Equals(x));

            return existingRecord != null;
        }

        public async Task<bool> IsEmailRegisteredAsync(string email, long personId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            return await dbContext.Persons
                .AnyAsync(x => x.Id != personId && x.Email == email);
        }

        public async Task<bool> IsMobileNoRegisteredAsync(string mobileNo)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var existingRecord = await dbContext.Persons
                .Select(x => x.MobileNo)
                .FirstOrDefaultAsync(x => mobileNo.Equals(x));

            return existingRecord != null;
        }

        public async Task<bool> IsMobileNoRegisteredAsync(string mobileNo, long personId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            return await dbContext.Persons
                .AnyAsync(x => x.Id != personId && x.MobileNo == mobileNo);
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
