using SmartSchool.Schema.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Types
{
    public class AcademicYearModel
    {
        public int? Year { get; set; } // Example: 2024 for the 2023-2024 academic year
        public DateOnly? StartDate { get; set; } // When the academic year starts
        public DateOnly? EndDate { get; set; } // When the academic year ends

        public IEnumerable<ClassStudentEnrollmentModel> ClassStudentEnrollments { get; set; } = [];

        public IEnumerable<ClassTeacherEnrollmentModel> ClassTeacherEnrollments { get; set; } = [];
    }
}
