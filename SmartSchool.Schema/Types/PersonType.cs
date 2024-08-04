using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Types
{
    public class PersonType : RecordType
    {
        public string? FullName { get; set; }
        public string? ShortName { get; set; }
        public string? Nickname { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? BcNo { get; set; }
        public SexType? Sex { get; set; }
        public string? NicNo { get; set; }
        public string? PassportNo { get; set; }
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        //public ICollection<Relationship> Relationships { get; set; } = [];
    }
}
