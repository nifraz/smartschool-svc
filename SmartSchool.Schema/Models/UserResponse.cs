using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using SmartSchool.Schema.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Models
{
    public class UserResponse
    {
        public long Id { get; set; }
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
        public long? SchoolId { get; set; }

        public bool IsGuardian { get; set; }
        public bool IsStudent { get; set; }
        public bool IsStaff { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsPrincipal { get; set; }

        public long? GuardianId { get; set; }
        public long? StudentId { get; set; }
        public long? StaffId { get; set; }
        public long? TeacherId { get; set; }
        public long? PrincipalId { get; set; }

        public PersonModel Person { get; set; }
    }
}
