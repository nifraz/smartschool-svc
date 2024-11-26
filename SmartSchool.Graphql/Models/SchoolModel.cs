using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class SchoolModel : AbstractRecordModel
    {
        public string? CensusNo { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public SchoolType? Type { get; set; }

        public int? DivisionId { get; set; }
        public string? Division { get; set; }

        public IEnumerable<SchoolStudentEnrollmentRequestModel> SchoolStudentEnrollmentRequests { get; set; } = [];
        public IEnumerable<SchoolStudentEnrollmentModel> SchoolStudentEnrollments { get; set; } = [];
        public IEnumerable<SchoolTeacherEnrollmentRequestModel> SchoolTeacherEnrollmentRequests { get; set; } = [];
        public IEnumerable<SchoolTeacherEnrollmentModel> SchoolTeacherEnrollments { get; set; } = [];
        public IEnumerable<SchoolPrincipalEnrollmentModel> SchoolPrincipalEnrollments { get; set; } = [];
        public IEnumerable<ClassModel> Classes { get; set; } = [];

    }
}
