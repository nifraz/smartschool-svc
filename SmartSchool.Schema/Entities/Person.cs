using Microsoft.EntityFrameworkCore;
using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    //[Index(nameof(NicNo), IsUnique = true)]
    //[Index(nameof(Email), IsUnique = true)]
    public class Person : Record
    {
        [Required]
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string? Nickname { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? BcNo { get; set; }
        public SexType Sex { get; set; }
        public string? NicNo { get; set; }
        public string? PassportNo { get; set; }
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        // foreign
        //public Student? Student { get; set; }
        //public Teacher? Teacher { get; set; }
        //public Guardian? Guardian { get; set; }

        //public ICollection<Relationship> Relationships { get; set; } = [];
    }
}
