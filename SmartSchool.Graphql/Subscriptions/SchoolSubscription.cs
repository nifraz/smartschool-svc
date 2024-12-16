using HotChocolate;
using HotChocolate.Types;
using SmartSchool.Graphql.Models;

namespace SmartSchool.Graphql.Subscriptions
{
    public class SchoolSubscription
    {
        [Subscribe]
        public SchoolModel SchoolProcessed([EventMessage] SchoolModel model) => model;

        [Subscribe]
        public SchoolStudentEnrollmentRequestModel SchoolStudentEnrollmentRequestProcessed([EventMessage] SchoolStudentEnrollmentRequestModel model) => model;

        [Subscribe]
        public SchoolStudentEnrollmentModel SchoolStudentEnrollmentProcessed([EventMessage] SchoolStudentEnrollmentModel model) => model;

        [Subscribe]
        public ClassStudentEnrollmentModel ClassStudentEnrollmentProcessed([EventMessage] ClassStudentEnrollmentModel model) => model;

        [Subscribe]
        public PrincipalModel PrincipalProcessed([EventMessage] PrincipalModel model) => model;
    }
}
