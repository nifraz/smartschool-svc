using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Class : AbstractRecord
    {
        public Grade Grade { get; set; }
        public string Section { get; set; }
        public string? Location { get; set; }

        //one
        [ForeignKey(nameof(School))]
        public long SchoolId { get; set; }
        public School School { get; set; }

        [ForeignKey(nameof(Language))]
        public string LanguageCode { get; set; }
        public Language Language { get; set; }

        //many
        [InverseProperty(nameof(ClassStudentEnrollment.Class))]
        public ICollection<ClassStudentEnrollment> ClassStudentEnrollments { get; set; } = [];

        [InverseProperty(nameof(ClassTeacherEnrollment.Class))]
        public ICollection<ClassTeacherEnrollment> ClassTeacherEnrollments { get; set; } = [];

        public override string ToString()
        {
            return $"{Grade.ToString()} {Section}";
        }
    }
}
