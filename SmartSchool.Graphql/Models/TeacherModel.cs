namespace SmartSchool.Graphql.Models
{
    public class TeacherModel : PersonModel
    {
        public IEnumerable<SchoolTeacherEnrollmentModel> RecentSchoolTeacherEnrollments { get; set; } = [];

    }
}
