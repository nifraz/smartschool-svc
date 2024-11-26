﻿using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class SchoolTeacherEnrollmentModel : AbstractRecordModel
    {
        public int? No { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? RemovedTime { get; set; }
        public EnrollmentStatus? Status { get; set; }

        public long? SchoolId { get; set; }
        public string? SchoolName { get; set; }

        public long? TeacherId { get; set; }

        public ICollection<ClassTeacherEnrollmentModel> TeacherClassEnrollments { get; set; } = [];
    }
}
