﻿using SmartSchool.Schema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Service
{
    public interface IAuthService
    {
        Task<AuthenticateResponse?> RegisterAsync(UserRegisterRequest model);
        Task<AuthenticateResponse?> LoginAsync(LoginRequest model);

        Task<bool> IsEmailRegistered(string email);
        Task<bool> IsEmailRegistered(int id, string email);
        Task<bool> IsMobileNoRegistered(string mobileNo);
        Task<bool> IsMobileNoRegistered(int id, string mobileNo);
    }
}