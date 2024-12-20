﻿using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class SchoolStudentEnrollmentModel : AbstractRecordModel
    {
        public int? No { get; set; }
        public DateTime? Time { get; set; }
        public EnrollmentStatus? Status { get; set; }

        public long? SchoolId { get; set; }
        public SchoolModel? School { get; set; }

        public long? StudentId { get; set; }
        public StudentModel? Student { get; set; }

        public long? SchoolStudentEnrollmentRequestId { get; set; }
        public SchoolStudentEnrollmentRequestModel? SchoolStudentEnrollmentRequest { get; set; }

        public IEnumerable<ClassStudentEnrollmentModel> RecentClassStudentEnrollments { get; set; } = [];

    }
}
