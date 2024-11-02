using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class ClassTeacherAssignment : AbstractRecord
    {
        public DateTime AssignedDate { get; set; }
        public DateTime? RemovedDate { get; set; }
        public string? RemoveReason { get; set; }

        //one
        [ForeignKey(nameof(TeacherEnrollment))]
        public long TeacherEnrollmentId { get; set; }
        public SchoolTeacherEnrollment TeacherEnrollment { get; set; }
        [ForeignKey(nameof(AcademicYear))]
        public long AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
        [ForeignKey(nameof(Class))]
        public long ClassId { get; set; }
        public Class Class { get; set; }
    }
}
