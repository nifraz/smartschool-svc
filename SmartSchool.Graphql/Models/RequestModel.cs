using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class RequestModel : AbstractRecordModel
    {
        public RequestStatus? Status { get; set; }
        public string? Reason { get; set; }
    }
}
