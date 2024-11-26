using SmartSchool.Schema.Entities;
using SmartSchool.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Service.Services
{
    public interface IAuthService
    {
        Task<UserResponse?> RegisterAsync(RegisterRequest model);
        Task<UserResponse> VerifyAsync(VerifyRequest model);

        Task<AuthenticateResponse?> LoginAsync(LoginRequest model);

        Task<bool> IsEmailRegisteredAsync(string email);
        Task<bool> IsEmailRegisteredAsync(string email, long personId);
        Task<bool> IsMobileNoRegisteredAsync(string mobileNo);
        Task<bool> IsMobileNoRegisteredAsync(string mobileNo, long personId);
    }
}
