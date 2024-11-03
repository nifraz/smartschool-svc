using SmartSchool.Schema.Enums;
using SmartSchool.Utility.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SmartSchool.Schema.Models
{
    public class UserRegisterRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Phone]
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [EnumValidation(typeof(Sex))]
        [Required]
        public Sex Sex { get; set; }
    }
}
