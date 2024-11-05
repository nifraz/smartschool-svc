﻿using SmartSchool.Schema.Enums;
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
    }
}