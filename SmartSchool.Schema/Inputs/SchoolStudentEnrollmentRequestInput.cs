using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Inputs
{
    public class SchoolStudentEnrollmentRequestInput
    {
        public long SchoolId { get; set; }
        public long StudentId { get; set; }
        public long PersonId { get; set; }
        public long ClassId { get; set; }
        public int AcademicYear { get; set; }
    }
}
