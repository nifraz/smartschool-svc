using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Class
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Grade { get; set; }
        public string? LanguageMedium { get; set; }
        public string? Location { get; set; }
        public long SchoolId { get; set; }
        public School School { get; set; }
        public ICollection<Admission> Admissions { get; set; }
        public ICollection<Teach> Teaches { get; set; }
    }
}
