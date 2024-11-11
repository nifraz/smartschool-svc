using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Service.Models
{
    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? MobileNo { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
