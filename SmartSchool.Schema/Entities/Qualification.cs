using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Qualification : Record
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime? AwardedDate { get; set; }
        public string? Type { get; set; }
        public ICollection<TeacherQualification> TeacherQualifications { get; set; } = [];
        public ICollection<StudentQualification> StudentQualifications { get; set; } = [];
        public ICollection<GuardianQualification> GuardianQualifications { get; set; } = [];

    }
}
