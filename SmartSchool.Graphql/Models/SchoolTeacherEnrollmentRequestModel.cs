using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class SchoolTeacherEnrollmentRequestModel : RequestModel
    {
        public Grade Grade { get; set; }

        public long? SchoolId { get; set; }

        public long? PersonId { get; set; }
        //public string? PersonFullName { get; set; }
        //public DateOnly? PersonDateOfBirth { get; set; }
        //public string? PersonNicNo { get; set; }
    }
}
