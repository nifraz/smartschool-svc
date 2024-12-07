using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class SchoolTeacherEnrollmentModel : AbstractRecordModel
    {
        public int? No { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? RemovedTime { get; set; }
        public EnrollmentStatus? Status { get; set; }

        public long? SchoolId { get; set; }
        public SchoolModel? School { get; set; }

        public long? TeacherId { get; set; }
        public TeacherModel? Teacher { get; set; }

        public ICollection<ClassTeacherEnrollmentModel> RecentTeacherClassEnrollments { get; set; } = [];

    }
}
