namespace SmartSchool.Graphql.Models
{
    public class UserModel : RecordModel
    {
        public long? PersonId { get; set; }
        public PersonModel? Person { get; set; }

        public long? CurrentSchoolId { get; set; }

        public long? GuardianId { get; set; }
        public long? StudentId { get; set; }
        public long? StaffId { get; set; }
        public long? TeacherId { get; set; }
        public long? PrincipalId { get; set; }

        public IEnumerable<SchoolStudentEnrollmentRequestModel> CreatedSchoolStudentEnrollmentRequests { get; set; } = [];
        public IEnumerable<SchoolStudentEnrollmentRequestModel> LastModifiedSchoolStudentEnrollmentRequests { get; set; } = [];
        public IEnumerable<SchoolStudentEnrollmentRequestModel> DeletedSchoolStudentEnrollmentRequests { get; set; } = [];
    }
}
