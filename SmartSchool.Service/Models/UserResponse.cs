using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Service.Models
{
    public class UserResponse
    {
        public long Id { get; set; }
        public string? Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public string? MobileNo { get; set; }
        public bool IsMobileNoVerified { get; set; }
    }
}
