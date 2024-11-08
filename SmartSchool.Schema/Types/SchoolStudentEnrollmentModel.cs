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
    public class SchoolStudentEnrollmentModel : RecordModel
    {
        public int? No { get; set; }
        public DateTime? Time { get; set; }
        public EnrollmentStatus? Status { get; set; }

        public long? SchoolId { get; set; }
        public string? SchoolName { get; set; }

        public IEnumerable<ClassStudentEnrollmentModel> ClassStudentEnrollments { get; set; } = [];
    }
}
