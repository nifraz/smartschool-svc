using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class SchoolStudentEnrollment : AbstractRecord
    {
        public int No { get; set; }
        public DateTime? Time { get; set; }
        public EnrollmentStatus Status { get; set; }

        //one
        [ForeignKey(nameof(School))]
        public long SchoolId { get; set; }
        public School School { get; set; }

        [ForeignKey(nameof(Student))]
        public long StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey(nameof(SchoolStudentEnrollmentRequest))]
        public long? SchoolStudentEnrollmentRequestId { get; set; }
        public SchoolStudentEnrollmentRequest? SchoolStudentEnrollmentRequest { get; set; }

        //many
        [InverseProperty(nameof(ClassStudentEnrollment.SchoolStudentEnrollment))]
        public ICollection<ClassStudentEnrollment> ClassStudentEnrollments { get; set; } = [];
    }
}
