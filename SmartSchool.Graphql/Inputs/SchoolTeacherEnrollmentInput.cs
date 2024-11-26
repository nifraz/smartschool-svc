using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Graphql.Inputs
{
    public class SchoolTeacherEnrollmentInput : AbstractRecordInput
    {
        [Required]
        public int No { get; set; }
        [Required]
        public long SchoolId { get; set; }
        [Required]
        public long TeacherId { get; set; }
    }
}
