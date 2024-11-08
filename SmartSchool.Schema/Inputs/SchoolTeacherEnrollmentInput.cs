using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Inputs
{
    public class SchoolTeacherEnrollmentInput
    {
        public int No { get; set; }
        public long SchoolId { get; set; }
        public long TeacherId { get; set; }
    }
}
