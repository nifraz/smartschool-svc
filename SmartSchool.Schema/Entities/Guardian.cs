using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Guardian : Person
    {
        public string? Occupation { get; set; }
        public string? Relation { get; set; }
        public ICollection<StudentGuardian> StudentGuardians { get; set; } = [];
    }
}
