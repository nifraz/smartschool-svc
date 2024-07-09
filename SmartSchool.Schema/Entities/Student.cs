using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Schema.Entities
{
    public class Student : Person
    {
        [Required]
        public string StudentId { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        
    }

}
