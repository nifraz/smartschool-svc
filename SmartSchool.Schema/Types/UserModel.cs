using AutoMapper;
using HotChocolate;
using SmartSchool.Schema.DataLoaders;
using SmartSchool.Schema.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchool.Schema.Types
{
    public class UserModel : PersonModel
    {
        public long? CurrentSchoolId { get; set; }

        public long? GuardianId { get; set; }
        public long? StudentId { get; set; }
        public long? StaffId { get; set; }
        public long? TeacherId { get; set; }
        public long? PrincipalId { get; set; }

        public IEnumerable<SchoolStudentEnrollmentRequestModel> CreatedSchoolStudentEnrollmentRequests { get; set; } = [];
        public IEnumerable<SchoolStudentEnrollmentRequestModel> LastModifiedSchoolStudentEnrollmentRequests { get; set; } = [];
        public IEnumerable<SchoolStudentEnrollmentRequestModel> DeletedSchoolStudentEnrollmentRequests { get; set; } = [];
    }
}
