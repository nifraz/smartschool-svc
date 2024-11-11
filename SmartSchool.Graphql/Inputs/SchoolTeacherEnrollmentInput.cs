namespace SmartSchool.Graphql.Inputs
{
    public class SchoolTeacherEnrollmentInput
    {
        public int No { get; set; }
        public long SchoolId { get; set; }
        public long TeacherId { get; set; }
    }
}
