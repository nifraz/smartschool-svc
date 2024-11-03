using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Schema.Models
{
    public class LoginRequest
    {
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? MobileNo { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
