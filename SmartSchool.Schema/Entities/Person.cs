using Microsoft.EntityFrameworkCore;
using SmartSchool.Schema.Classes;
using SmartSchool.Schema.Enums;
using SmartSchool.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    //[Index(nameof(NicNo), IsUnique = true)]
    //[Index(nameof(Email), IsUnique = true)]
    public class Person : AbstractRecord
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string? Nickname { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? BcNo { get; set; }
        public Sex Sex { get; set; }
        public string? NicNo { get; set; }
        public string? PassportNo { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }

        //one
        [InverseProperty(nameof(User.Person))]
        public User? User { get; set; }

        [InverseProperty(nameof(Student.Person))]
        public Student? Student { get; set; }

        [InverseProperty(nameof(Teacher.Person))]
        public Teacher? Teacher { get; set; }

        [InverseProperty(nameof(Principal.Person))]
        public Principal? Principal { get; set; }

        //many
        [InverseProperty(nameof(SchoolStudentEnrollmentRequest.Person))]
        public ICollection<SchoolStudentEnrollmentRequest> SchoolStudentEnrollmentRequests { get; set; } = [];

        [InverseProperty(nameof(SchoolTeacherEnrollmentRequest.Person))]
        public ICollection<SchoolTeacherEnrollmentRequest> SchoolTeacherEnrollmentRequests { get; set; } = [];


        [InverseProperty(nameof(PersonRelationship.Person1))]
        public ICollection<PersonRelationship> Person1Relationships { get; set; } = [];

        [InverseProperty(nameof(PersonRelationship.Person2))]
        public ICollection<PersonRelationship> Person2Relationships { get; set; } = [];

        [NotMapped]
        public Age Age
        {
            get
            {
                return DateOfBirth != null
                    ? CalculateExactAge(DateOfBirth.Value)
                    : new Age { Years = 0, Months = 0, Days = 0 };
            }
        }

        private static Age CalculateExactAge(DateOnly dateOfBirth)
        {
            var (years, months, days) = dateOfBirth.GetAge(DateTime.Today);

            return new Age
            {
                Years = years,
                Months = months,
                Days = days,
            };
        }
    }
}
