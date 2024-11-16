using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Inputs
{
    public class SchoolStudentEnrollmentRequestStatusUpdateInput
    {
        public long? Id { get; set; }

        public RequestStatus Status { get; set; }
        public string? Reason { get; set; }
    }
}
