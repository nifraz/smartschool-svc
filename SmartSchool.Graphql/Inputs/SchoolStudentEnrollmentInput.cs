namespace SmartSchool.Graphql.Inputs
{
    public class SchoolStudentEnrollmentInput
    {
        public long? Id { get; set; }

        public int? No { get; set; }
        public long? SchoolStudentEnrollmentRequestId { get; set; }
        public long SchoolId { get; set; }
        public long PersonId { get; set; }
        public long ClassId { get; set; }
        public DateTime? Time { get; set; }
        public int AcademicYearYear { get; set; }

    }
}
