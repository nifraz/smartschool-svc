using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Inputs
{
    public class SchoolTeacherEnrollmentRequestInput
    {
        public long SchoolId { get; set; }
        public long TeacherId { get; set; }
        public long PersonId { get; set; }
    }
}
