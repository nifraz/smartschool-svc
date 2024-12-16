using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Graphql.Models
{
    public class SchoolReportModel
    {
        public DateTime CurrentDate { get; set; }

        public SchoolModel? School { get; set; }
        public PrincipalModel? Principal { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public long NoOfStudentEnrollmentRequests { get; set; }
        public long NoOfApprovedStudentEnrollmentRequests { get; set; }
        public long NoOfRejectedStudentEnrollmentRequests { get; set; }
        public long NoOfCancelledStudentEnrollmentRequests { get; set; }

        public long NoOfStudentEnrollments { get; set; }
        public long NoOfActiveStudentEnrollments { get; set; }
        public long NoOfLeftStudentEnrollments { get; set; }
        public long NoOfCompletedStudentEnrollments { get; set; }
        public long NoOfCancelledStudentEnrollments { get; set; }

        public long NoOfTeacherEnrollments { get; set; }
        public long NoOfActiveTeacherEnrollments { get; set; }
        public long NoOfRetiredTeacherEnrollments { get; set; }
        public long NoOfResignedTeacherEnrollments { get; set; }
        public long NoOfCancelledTeacherEnrollments { get; set; }
    }
}
