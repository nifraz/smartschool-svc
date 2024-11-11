namespace SmartSchool.Graphql.Models
{
    public class PrincipalModel : PersonModel
    {
        public IEnumerable<SchoolPrincipalEnrollmentModel> SchoolPrincipalEnrollments { get; set; } = [];
    }
}
