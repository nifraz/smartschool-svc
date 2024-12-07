namespace SmartSchool.Graphql.Models
{
    public class PrincipalModel : PersonModel
    {
        public IEnumerable<SchoolPrincipalEnrollmentModel> RecentSchoolPrincipalEnrollments { get; set; } = [];
    }
}
