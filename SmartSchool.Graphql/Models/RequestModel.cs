using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class RequestModel : RecordModel
    {
        public RequestStatus? Status { get; set; }
        public string? Reason { get; set; }
    }
}
