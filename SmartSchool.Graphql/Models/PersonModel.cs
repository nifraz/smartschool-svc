using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using SmartSchool.Utility.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchool.Graphql.Models
{
    public class PersonModel : AbstractRecordModel
    {
        public string? FullName { get; set; }
        public string? ShortName { get; set; }
        public string? Nickname { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? BcNo { get; set; }
        public Sex? Sex { get; set; }
        public string? NicNo { get; set; }
        public string? PassportNo { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }

        public AgeModel? Age  { get; set; }

        public IEnumerable<SchoolStudentEnrollmentRequestModel> RecentSchoolStudentEnrollmentRequests { get; set; } = [];
        public IEnumerable<SchoolTeacherEnrollmentRequestModel> RecentSchoolTeacherEnrollmentRequests { get; set; } = [];
        public IEnumerable<PersonRelationshipModel> RecentPerson1Relationships { get; set; } = [];
        public IEnumerable<PersonRelationshipModel> RecentPerson2Relationships { get; set; } = [];


    }
}
