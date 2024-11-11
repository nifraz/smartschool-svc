using HotChocolate;
using HotChocolate.Types;
using SmartSchool.Graphql.Models;

namespace SmartSchool.Graphql.Subscriptions
{
    public class SchoolSubscription
    {
        [Subscribe]
        public SchoolStudentEnrollmentModel SchoolStudentEnrollmentCreated([EventMessage] SchoolStudentEnrollmentModel model) => model;
    }
}
