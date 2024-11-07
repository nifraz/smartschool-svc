using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class SchoolPrincipalEnrollment : AbstractRecord
    {
        public int No { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? RemovedTime { get; set; }
        public EnrollmentStatus Status { get; set; }

        //one
        [ForeignKey(nameof(School))]
        public long SchoolId { get; set; }
        public School School { get; set; }

        [ForeignKey(nameof(Principal))]
        public long PrincipalId { get; set; }
        public Principal Principal { get; set; }
    }
}
