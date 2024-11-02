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
    public class SchoolStudentAdmission : AbstractRecord
    {
        public int No { get; set; }
        public StudentAdmissionStatus Status { get; set; }

        //one
        [ForeignKey(nameof(School))]
        public long SchoolId { get; set; }
        public School School { get; set; }

        [ForeignKey(nameof(Student))]
        public long StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey(nameof(StudentAdmissionRequest))]
        public long? StudentAdmissionRequestId { get; set; }
        public SchoolStudentAdmissionRequest? StudentAdmissionRequest { get; set; }

        //many
        [InverseProperty(nameof(ClassStudentAssignment.StudentAdmission))]
        public ICollection<ClassStudentAssignment> StudentClassAssignments { get; set; } = [];
    }
}
