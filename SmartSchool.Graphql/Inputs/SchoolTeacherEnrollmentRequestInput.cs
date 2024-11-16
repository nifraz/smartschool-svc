namespace SmartSchool.Graphql.Inputs
{
    public class SchoolTeacherEnrollmentRequestInput
    {
        public long? Id { get; set; }

        public long SchoolId { get; set; }
        public long TeacherId { get; set; }
        public long PersonId { get; set; }
    }
}
