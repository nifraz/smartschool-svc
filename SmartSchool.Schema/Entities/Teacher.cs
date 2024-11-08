using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Teacher : AbstractRecord
    {
        public string? RegistrationNo { get; set; }
        public string? ServiceGrade { get; set; }

        //one
        [ForeignKey(nameof(Person))]
        public long PersonId { get; set; }
        public Person Person { get; set; }

        //many
        [InverseProperty(nameof(SchoolTeacherEnrollment.Teacher))]
        public ICollection<SchoolTeacherEnrollment> SchoolTeacherEnrollments { get; set; } = [];
    }
}
