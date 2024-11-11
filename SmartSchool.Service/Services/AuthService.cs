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
        public async Task<RegisterResponse?> RegisterAsync(RegisterRequest model)
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
                user.EmailVerificationOtp = OtpGenerator.GenerateOtp();
                user.EmailVerificationToken = Guid.NewGuid().ToString();
                user.Person = person;

                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();

                //_ = Task.Run(() => notificationService.SendRegistrationCompletedEmailAsync(user));
                await notificationService.SendRegistrationCompletedEmailAsync(user);

                //await notificationService.SendRegistrationCompletedSmsAsync(model);
                await dbContext.Database.CommitTransactionAsync();
                return mapper.Map<RegisterResponse>(user);
            }
            catch (Exception)
            {
                await dbContext.Database.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<VerifyEmailResponse> VerifyEmailAsync(VerifyEmailRequest model)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var existingUser = await dbContext.Users
                .Include(x => x.Person)
                .FirstOrDefaultAsync(x => x.Person.Email == model.Email) ?? throw new KeyNotFoundException($"No matching User found (email={model.Email})");

            if (string.IsNullOrWhiteSpace(model.Otp) && string.IsNullOrWhiteSpace(model.Token))
            {
                throw new UnauthorizedAccessException($"OTP or Token is required.");
            }

            if (!string.IsNullOrWhiteSpace(model.Otp) && existingUser.EmailVerificationOtp != model.Otp)
            {
                throw new UnauthorizedAccessException($"The verification code entered is incorrect.");
            }

            if (!string.IsNullOrWhiteSpace(model.Token) && existingUser.EmailVerificationToken != model.Token)
            {
                throw new UnauthorizedAccessException($"The verification token is invalid.");
            }

            existingUser.IsEmailVerified = true;
            await dbContext.SaveChangesAsync();

            return mapper.Map<VerifyEmailResponse>(existingUser);
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
