using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
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
        public long? StudentId { get; set; }
        public string? StudentFullName { get; set; }

        public int? AcademicYear { get; set; }
    }
}
