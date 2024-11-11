using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Inputs
{
    public class SchoolStudentEnrollmentRequestInput
    {
        public Grade Grade { get; set; }
        public long SchoolId { get; set; }
        public long PersonId { get; set; }
        //public long StudentId { get; set; }
        public int AcademicYearYear { get; set; }
    }
}
