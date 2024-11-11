using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Inputs
{
    public class SchoolStudentEnrollmentRequestStatusUpdateInput
    {
        public RequestStatus Status { get; set; }
        public string? Reason { get; set; }
    }
}
