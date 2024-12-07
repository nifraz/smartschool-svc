using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Models
{
    public class SchoolPrincipalEnrollmentModel : AbstractRecordModel
    {
        public int? No { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? RemovedTime { get; set; }
        public EnrollmentStatus? Status { get; set; }

        public long? SchoolId { get; set; }
        public SchoolModel? School { get; set; }

        public long? PrincipalId { get; set; }
        public PrincipalModel? Principal { get; set; }

    }
}
