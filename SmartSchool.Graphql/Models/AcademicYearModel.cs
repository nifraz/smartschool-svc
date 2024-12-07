namespace SmartSchool.Graphql.Models
{
    public class AcademicYearModel
    {
        public int? Year { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public IEnumerable<ClassStudentEnrollmentModel> RecentClassStudentEnrollments { get; set; } = [];
        public IEnumerable<ClassTeacherEnrollmentModel> RecentClassTeacherEnrollments { get; set; } = [];
    }
}
