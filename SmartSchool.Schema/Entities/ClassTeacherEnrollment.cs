using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class ClassTeacherEnrollment : AbstractRecord
    {
        public DateTime? Time { get; set; }
        public DateTime? RemovedTime { get; set; }
        public string? RemovedReason { get; set; }
        public EnrollmentStatus Status { get; set; }

        //one
        [ForeignKey(nameof(Class))]
        public long ClassId { get; set; }
        public Class Class { get; set; }

        [ForeignKey(nameof(SchoolTeacherEnrollment))]
        public long SchoolTeacherEnrollmentId { get; set; }
        public SchoolTeacherEnrollment SchoolTeacherEnrollment { get; set; }

        [ForeignKey(nameof(AcademicYear))]
        public int AcademicYearYear { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }
}
