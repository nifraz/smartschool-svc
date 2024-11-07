using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class AcademicYear
    {
        [Key]
        public int Year { get; set; } // Example: 2024 for the 2023-2024 academic year
        public DateOnly StartDate { get; set; } // When the academic year starts
        public DateOnly EndDate { get; set; } // When the academic year ends

        //many
        [InverseProperty(nameof(ClassStudentEnrollment.AcademicYear))]
        public ICollection<ClassStudentEnrollment> ClassStudentEnrollments { get; set; } = [];

        [InverseProperty(nameof(ClassTeacherEnrollment.AcademicYear))]
        public ICollection<ClassTeacherEnrollment> ClassTeacherEnrollments { get; set; } = [];
    }

}
