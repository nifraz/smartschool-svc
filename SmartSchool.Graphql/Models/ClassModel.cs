using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class ClassModel : AbstractRecordModel
    {
        public Grade? Grade { get; set; }
        public string? Section { get; set; }
        public string? Location { get; set; }

        public long? SchoolId { get; set; }
        public SchoolModel? School { get; set; }

        public string? LanguageCode { get; set; }
        public LanguageModel? Language { get; set; }

        public IEnumerable<ClassStudentEnrollmentModel> RecentClassStudentEnrollments { get; set; } = [];
        public IEnumerable<ClassTeacherEnrollmentModel> RecentClassTeacherEnrollments { get; set; } = [];

    }
}
