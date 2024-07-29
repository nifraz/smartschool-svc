using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Teacher : Person
    {
        public string RegistrationNo { get; set; }
        public DateTime? PensionDate { get; set; }
        public string? ServiceGrade { get; set; }

        public ICollection<Teach> Teaches { get; set; } = [];
    }
}
