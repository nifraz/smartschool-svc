namespace SmartSchool.Graphql.Inputs
{
    public class SchoolTeacherEnrollmentInput
    {
        public long? Id { get; set; }

        public int No { get; set; }
        public long SchoolId { get; set; }
        public long TeacherId { get; set; }
    }
}
