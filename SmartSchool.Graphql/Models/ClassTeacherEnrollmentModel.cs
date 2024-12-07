using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class ClassTeacherEnrollmentModel : AbstractRecordModel
    {
        public DateTime? Time { get; set; }
        public DateTime? RemovedTime { get; set; }
        public string? RemovedReason { get; set; }
        public EnrollmentStatus? Status { get; set; }

        public long? ClassId { get; set; }
        public ClassModel? Class { get; set; }

        public long? SchoolTeacherEnrollmentId { get; set; }
        public SchoolTeacherEnrollmentModel? SchoolTeacherEnrollment { get; set; }

        public long? TeacherId { get; set; }
        public TeacherModel? Teacher { get; set; }

        public int? AcademicYearYear { get; set; }
        public AcademicYearModel? AcademicYear { get; set; }

    }
}
