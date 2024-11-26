using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Graphql.Inputs
{
    public class SchoolStudentEnrollmentInput : AbstractRecordInput
    {
        public int? No { get; set; }
        public long? SchoolStudentEnrollmentRequestId { get; set; }
        [Required]
        public long SchoolId { get; set; }
        [Required]
        public long PersonId { get; set; }
        [Required]
        public long ClassId { get; set; }
        public DateTime? Time { get; set; }
        [Required]
        public int AcademicYearYear { get; set; }

    }
}
