using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Service.Models
{
    public class JwtData(string token, DateTime expires)
    {
        public string Token { get; set; } = token;
        public DateTime Expires { get; set; } = expires;
    }
}
