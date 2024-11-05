using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Principal : AbstractRecord
    {
        //one
        [ForeignKey(nameof(Person))]
        public long PersonId { get; set; }
        public Person Person { get; set; }

        //many
        [InverseProperty(nameof(SchoolPrincipalEnrollment.Principal))]
        public ICollection<SchoolPrincipalEnrollment> SchoolPrincipalEnrollments { get; set; } = [];

    }
}
