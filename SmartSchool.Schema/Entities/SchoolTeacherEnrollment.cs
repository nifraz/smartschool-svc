using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class SchoolTeacherEnrollment : AbstractRecord
    {
        public int No { get; set; }
        public EnrollmentStatus Status { get; set; }

        //one
        [ForeignKey(nameof(School))]
        public long SchoolId { get; set; }
        public School School { get; set; }

        [ForeignKey(nameof(Teacher))]
        public long TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        //many
        [InverseProperty(nameof(ClassTeacherAssignment.TeacherEnrollment))]
        public ICollection<ClassTeacherAssignment> TeacherClassAssignments { get; set; } = [];
    }
}
