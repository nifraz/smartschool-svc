using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class AcademicYear : AbstractRecord
    {
        public int Year { get; set; } // Example: 2024 for the 2023-2024 academic year
        public DateOnly StartDate { get; set; } // When the academic year starts
        public DateOnly EndDate { get; set; } // When the academic year ends

        //many
        [InverseProperty(nameof(ClassStudentAssignment.AcademicYear))]
        public ICollection<ClassStudentAssignment> StudentClassAssignments { get; set; } = [];

        [InverseProperty(nameof(ClassTeacherAssignment.AcademicYear))]
        public ICollection<ClassTeacherAssignment> TeacherClassAssignments { get; set; } = [];
    }

}
