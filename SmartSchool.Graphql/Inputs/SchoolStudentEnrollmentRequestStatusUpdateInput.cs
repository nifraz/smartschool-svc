using SmartSchool.Schema.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Graphql.Inputs
{
    public class SchoolStudentEnrollmentRequestStatusUpdateInput : AbstractRecordInput
    {
        [Required]
        public RequestStatus Status { get; set; }
        public string? Reason { get; set; }
    }
}
