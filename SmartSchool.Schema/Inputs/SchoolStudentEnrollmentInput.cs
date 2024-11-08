using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Inputs
{
    public class SchoolStudentEnrollmentInput
    {
        public int No { get; set; }
        public long SchoolId { get; set; }
        public long StudentId { get; set; }
        public long ClassId { get; set; }
        public int AcademicYear { get; set; }

    }
}
