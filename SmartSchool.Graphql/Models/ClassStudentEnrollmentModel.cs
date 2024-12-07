using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class ClassStudentEnrollmentModel : AbstractRecordModel
    {
        public int? RollNo { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? RemovedTime { get; set; }
        public string? RemoveReason { get; set; }
        public EnrollmentStatus? Status { get; set; }

        public long? ClassId { get; set; }
        public ClassModel? Class { get; set; }

        public long? SchoolStudentEnrollmentId { get; set; }
        public SchoolStudentEnrollmentModel? SchoolStudentEnrollment { get; set; }

        public long? StudentId { get; set; }
        public StudentModel? Student { get; set; }

        public int? AcademicYearYear { get; set; }
        public AcademicYear? AcademicYear { get; set; }

    }
}
