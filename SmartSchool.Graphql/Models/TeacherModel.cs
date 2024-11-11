namespace SmartSchool.Graphql.Models
{
    public class TeacherModel : PersonModel
    {
        public IEnumerable<SchoolTeacherEnrollmentModel> SchoolTeacherEnrollments { get; set; } = [];

    }
}
