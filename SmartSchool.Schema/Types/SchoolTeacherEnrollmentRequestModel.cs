using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Types
{
    public class SchoolTeacherEnrollmentRequestModel : RequestModel
    {
        public Grade Grade { get; set; }

        public long? SchoolId { get; set; }

        public long? PersonId { get; set; }
        //public string? PersonFullName { get; set; }
        //public DateOnly? PersonDateOfBirth { get; set; }
        //public string? PersonNicNo { get; set; }
    }
}
