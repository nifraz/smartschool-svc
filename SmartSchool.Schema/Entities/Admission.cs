using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Admission : Record
    {
        [Required]
        public DateTime Date { get; set; }
        public long SchoolId { get; set; }
        public School School { get; set; }
        public long StudentId { get; set; }
        public Student Student { get; set; }
        public long ClassId { get; set; }
        public Class Class { get; set; }
        public long? LeaveId { get; set; }
        public Leave? Leave { get; set; }
    }
}
