using SmartSchool.Schema.Entities;
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
        public Division? Division { get; set; }

        public IEnumerable<SchoolStudentEnrollmentRequestModel> RecentSchoolStudentEnrollmentRequests { get; set; } = [];
        public IEnumerable<SchoolStudentEnrollmentModel> RecentSchoolStudentEnrollments { get; set; } = [];
        public IEnumerable<SchoolTeacherEnrollmentRequestModel> RecentSchoolTeacherEnrollmentRequests { get; set; } = [];
        public IEnumerable<SchoolTeacherEnrollmentModel> RecentSchoolTeacherEnrollments { get; set; } = [];
        public IEnumerable<SchoolPrincipalEnrollmentModel> RecentSchoolPrincipalEnrollments { get; set; } = [];
        public IEnumerable<ClassModel> AllClasses { get; set; } = [];

    }
}
