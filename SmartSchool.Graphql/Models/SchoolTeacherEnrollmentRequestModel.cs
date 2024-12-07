using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class SchoolTeacherEnrollmentRequestModel : RequestModel
    {
        public Grade Grade { get; set; }

        public long? SchoolId { get; set; }
        public SchoolModel? School { get; set; }

        public long? PersonId { get; set; }
        public PersonModel? Person { get; set; }

        public long? TeacherId { get; set; }
        public TeacherModel? Teacher { get; set; }

    }
}
