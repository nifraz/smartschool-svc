using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class SchoolStudentEnrollmentRequest : AbstractRecord
    {
        public Grade Grade { get; set; }
        public RequestStatus Status { get; set; }

        //one
        [ForeignKey(nameof(School))]
        public long SchoolId { get; set; }
        public School School { get; set; }

        [ForeignKey(nameof(Person))]
        public long PersonId { get; set; }
        public Person Person { get; set; }

        [ForeignKey(nameof(AcademicYear))]
        public int AcademicYearYear { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }
}
