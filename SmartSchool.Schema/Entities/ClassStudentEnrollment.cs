using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class ClassStudentEnrollment : AbstractRecord
    {
        public int? RollNo { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? RemovedTime { get; set; }
        public string? RemoveReason { get; set; }
        public EnrollmentStatus Status { get; set; }

        //one
        [ForeignKey(nameof(Class))]
        public long ClassId { get; set; }
        public Class Class { get; set; }

        [ForeignKey(nameof(SchoolStudentEnrollment))]
        public long SchoolStudentEnrollmentId { get; set; }
        public SchoolStudentEnrollment SchoolStudentEnrollment { get; set; }

        [ForeignKey(nameof(AcademicYear))]
        public int AcademicYearYear { get; set; }
        public AcademicYear AcademicYear { get; set; }


    }
}
