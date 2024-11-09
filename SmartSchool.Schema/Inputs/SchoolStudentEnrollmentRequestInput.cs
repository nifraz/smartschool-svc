using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Inputs
{
    public class SchoolStudentEnrollmentRequestInput
    {
        public Grade Grade { get; set; }
        public long SchoolId { get; set; }
        public long PersonId { get; set; }
        //public long StudentId { get; set; }
        public int AcademicYearYear { get; set; }
    }
}
