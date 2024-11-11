using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class SchoolStudentEnrollmentRequestModel : RequestModel
    {
        public Grade? Grade { get; set; }

        public long? SchoolId { get; set; }
        public SchoolModel? School { get; set; }
        public string? SchoolName { get; set; }

        public long? PersonId { get; set; }
        public PersonModel? Person { get; set; }
        public string? PersonFullName { get; set; }

        public int? AcademicYearYear { get; set; }
        public AcademicYearModel? AcademicYear { get; set; }

        public SchoolStudentEnrollmentModel? SchoolStudentEnrollment { get; set; }
    }
}
