using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class SchoolStudentEnrollmentRequest : AbstractRequest
    {
        public Grade Grade { get; set; }

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

        [InverseProperty(nameof(SchoolStudentEnrollment.SchoolStudentEnrollmentRequest))]
        public SchoolStudentEnrollment? SchoolStudentEnrollment { get; set; }
    }
}
