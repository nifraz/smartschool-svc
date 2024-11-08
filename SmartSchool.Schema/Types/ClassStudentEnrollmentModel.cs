using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Types
{
    public class ClassStudentEnrollmentModel : RecordModel
    {
        public int? RollNo { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? RemovedTime { get; set; }
        public string? RemoveReason { get; set; }
        public EnrollmentStatus? Status { get; set; }

        public long? ClassId { get; set; }

        public long? SchoolStudentEnrollmentId { get; set; }

        public int? AcademicYear { get; set; }
    }
}
