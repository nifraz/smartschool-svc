using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class ClassModel : RecordModel
    {
        public Grade? Grade { get; set; }
        public string? Section { get; set; }
        public string? Location { get; set; }

        public long? SchoolId { get; set; }
        public SchoolModel? School { get; set; }

        public string? LanguageCode { get; set; }
        public string? LanguageName { get; set; }

        public IEnumerable<ClassStudentEnrollmentModel> ClassStudentEnrollments { get; set; } = [];

        public IEnumerable<ClassTeacherEnrollmentModel> ClassTeacherEnrollments { get; set; } = [];
    }
}
