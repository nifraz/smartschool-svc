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

        Task<bool> IsEmailRegistered(string email);
        Task<bool> IsEmailRegistered(int id, string email);
        Task<bool> IsMobileNoRegistered(string mobileNo);
        Task<bool> IsMobileNoRegistered(int id, string mobileNo);
    }
}
