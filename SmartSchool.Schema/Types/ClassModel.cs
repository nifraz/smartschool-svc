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
    public class ClassModel
    {
        public Grade? Grade { get; set; }
        public string? Section { get; set; }
        public string? Location { get; set; }

        public long? SchoolId { get; set; }

        public string? LanguageCode { get; set; }
        public string? LanguageName { get; set; }

        public IEnumerable<ClassStudentEnrollmentModel> ClassStudentEnrollments { get; set; } = [];

        public IEnumerable<ClassTeacherEnrollmentModel> ClassTeacherEnrollments { get; set; } = [];
    }
}
