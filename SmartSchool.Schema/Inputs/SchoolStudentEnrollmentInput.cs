using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Inputs
{
    public class SchoolStudentEnrollmentInput
    {
        public int? No { get; set; }
        public long? SchoolStudentEnrollmentRequestId { get; set; }
        public long SchoolId { get; set; }
        public long PersonId { get; set; }
        public long ClassId { get; set; }
        public DateTime? Time { get; set; }
        public int AcademicYearYear { get; set; }

    }
}
