﻿using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class SchoolTeacherEnrollmentRequest : AbstractRequest
    {
        //one
        [ForeignKey(nameof(School))]
        public long SchoolId { get; set; }
        public School School { get; set; }

        [ForeignKey(nameof(Person))]
        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
