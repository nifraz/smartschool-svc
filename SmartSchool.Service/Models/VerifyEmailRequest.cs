using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Service.Models
{
    public class VerifyEmailRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string? Otp { get; set; }
        public string? Token { get; set; }

    }
}
