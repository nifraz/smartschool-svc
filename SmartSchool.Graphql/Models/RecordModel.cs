using HotChocolate.Data;

namespace SmartSchool.Graphql.Models
{
    public class RecordModel
    {
        [IsProjected(true)]
        public long? Id { get; set; }
        public string? Label { get; set; }
        public string? Notes { get; set; }

        public DateTime? CreatedTime { get; set; }
        public long? CreatedUserId { get; set; }
        public UserModel? CreatedUser { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public long? LastModifiedUserId { get; set; }
        public UserModel? LastModifiedUser { get; set; }
        public DateTime? DeletedTime { get; set; }
        public long? DeletedUserId { get; set; }
        public UserModel? DeletedUser { get; set; }
    }
}
