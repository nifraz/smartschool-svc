using SmartSchool.Schema.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Graphql.Inputs
{
    public class SchoolStudentEnrollmentRequestInput : AbstractRecordInput
    {
        [Required]
        public Grade Grade { get; set; }
        [Required]
        public long SchoolId { get; set; }
        [Required]
        public long PersonId { get; set; }
        [Required]
        public int AcademicYearYear { get; set; }
    }
}
