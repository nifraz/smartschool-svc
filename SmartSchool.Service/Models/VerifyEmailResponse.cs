using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Service.Models
{
    public class VerifyEmailResponse
    {
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }

    }
}
