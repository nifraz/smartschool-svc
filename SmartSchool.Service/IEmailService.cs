﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Service
{
    public interface IEmailService
    {
        Task SendVerificationEmailAsync(string toEmail, string token);
    }
}
