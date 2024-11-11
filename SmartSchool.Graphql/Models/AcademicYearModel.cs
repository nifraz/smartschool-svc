namespace SmartSchool.Graphql.Models
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
