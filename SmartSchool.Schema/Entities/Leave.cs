using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Leave : Record
    {
        [Required]
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
        public long StudentId { get; set; }
        public Student Student { get; set; }
        public long SchoolId { get; set; }
        public School School { get; set; }
    }
}
