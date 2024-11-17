using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Service.Models
{
    public class VerifyRequest
    {
        [EmailAddress]
        public string? Email { get; set; }
        public string? EmailOtp { get; set; }
        public string? EmailToken { get; set; }

        public string? MobileNo { get; set; }
        public string? MobileNoOtp { get; set; }
        public string? MobileNoToken { get; set; }
    }
}
