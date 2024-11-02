using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchool.Schema.Entities
{
    public abstract class AbstractRecord
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime? CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public DateTime? DeletedTime { get; set; }

        //one

        [ForeignKey(nameof(CreatedUser))]
        public long? CreatedUserId { get; set; }
        public User? CreatedUser { get; set; }

        [ForeignKey(nameof(LastModifiedUser))]
        public long? LastModifiedUserId { get; set; }
        public User? LastModifiedUser { get; set; }

        [ForeignKey(nameof(DeletedUser))]
        public long? DeletedUserId { get; set; }
        public User? DeletedUser { get; set; }
    }
}
