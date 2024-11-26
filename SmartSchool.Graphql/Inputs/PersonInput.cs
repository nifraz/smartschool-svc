using SmartSchool.Schema.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.Graphql.Inputs
{
    public class PersonInput : AbstractRecordInput
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string ShortName { get; set; }
        public string? Nickname { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? BcNo { get; set; }
        [Required]
        public Sex Sex { get; set; }
        public string? NicNo { get; set; }
        public string? PassportNo { get; set; }
        public string? MobileNo { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }

        //public ICollection<Relationship> Relationships { get; set; } = [];
    }
}
