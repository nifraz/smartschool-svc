using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Graphql.Inputs
{
    public class SchoolTeacherEnrollmentRequestInput : AbstractRecordInput
    {
        [Required]
        public long SchoolId { get; set; }
        [Required]
        public long TeacherId { get; set; }
        [Required]
        public long PersonId { get; set; }
    }
}
