namespace SmartSchool.Graphql.Models
{
    public class StudentModel : PersonModel
    {
        public IEnumerable<SchoolStudentEnrollmentModel> RecentSchoolStudentEnrollments { get; set; } = [];

    }
}
