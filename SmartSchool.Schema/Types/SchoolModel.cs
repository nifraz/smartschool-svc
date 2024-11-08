using AutoMapper;
using HotChocolate;
using SmartSchool.Schema.DataLoaders;
using SmartSchool.Schema.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchool.Schema.Types
{
    public class SchoolModel : RecordModel
    {
        public string? CensusNo { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public Enums.SchoolType? Type { get; set; }

        public int? DivisionId { get; set; }
        public string? Division { get; set; }

        public IEnumerable<SchoolStudentEnrollmentRequestModel> SchoolStudentEnrollmentRequests { get; set; } = [];
        public IEnumerable<SchoolStudentEnrollmentModel> SchoolStudentEnrollments { get; set; } = [];
        public IEnumerable<SchoolTeacherEnrollmentRequestModel> SchoolTeacherEnrollmentRequests { get; set; } = [];
        public IEnumerable<SchoolTeacherEnrollmentModel> SchoolTeacherEnrollments { get; set; } = [];
        public IEnumerable<SchoolPrincipalEnrollmentModel> SchoolPrincipalEnrollments { get; set; } = [];
        public IEnumerable<ClassModel> Classes { get; set; } = [];

    }
}
