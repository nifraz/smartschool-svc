using HotChocolate.Types;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSchool.Schema.Types;

namespace SmartSchool.Schema.Subscriptions
{
    public class SchoolSubscription
    {
        [Subscribe]
        public SchoolStudentEnrollmentModel SchoolStudentEnrollmentCreated([EventMessage] SchoolStudentEnrollmentModel model) => model;
    }
}
