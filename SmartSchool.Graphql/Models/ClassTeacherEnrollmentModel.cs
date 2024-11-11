using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class ClassTeacherEnrollmentModel : RecordModel
    {
        public DateTime? Time { get; set; }
        public DateTime? RemovedTime { get; set; }
        public string? RemovedReason { get; set; }
        public EnrollmentStatus? Status { get; set; }

        public long? ClassId { get; set; }

        public long? SchoolTeacherEnrollmentId { get; set; }

        public int? AcademicYear { get; set; }
    }
}
