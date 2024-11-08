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
    public class SchoolStudentEnrollmentRequestModel : RecordModel
    {
        public Grade? Grade { get; set; }
        public RequestStatus? Status { get; set; }

        public long? SchoolId { get; set; }
        public SchoolModel? School { get; set; }
        public string? SchoolName { get; set; }

        public long? PersonId { get; set; }
        public PersonModel? Person { get; set; }
        public string? PersonFullName { get; set; }
    }
}
