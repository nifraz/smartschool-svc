using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class StudentGuardian : Record
    {
        public long StudentId { get; set; }
        public Student Student { get; set; }
        public long GuardianId { get; set; }
        public Guardian Guardian { get; set; }
    }
}
