using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchool.Graphql.Inputs
{
    public class SchoolInput : AbstractRecordInput
    {
        [Required]
        public string CensusNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public string? Address { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        [Required]
        public SchoolType Type { get; set; }
        [Required]
        public int DivisionId { get; set; }
    }
}
