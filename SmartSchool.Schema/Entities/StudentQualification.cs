using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class StudentQualification : Record
    {
        public long TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public long QualificationId { get; set; }
        public Qualification Qualification { get; set; }
    }
}
