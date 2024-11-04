using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Schema.Models
{
    public class UserLoginRequest
    {
        public string? Email { get; set; }
        public string? MobileNo { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
