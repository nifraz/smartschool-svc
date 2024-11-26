namespace SmartSchool.Graphql.Models
{
    public class UserModel : AbstractRecordModel
    {
        public bool? IsEmailVerified { get; set; }
        public bool? IsMobileNoVerified { get; set; }

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
