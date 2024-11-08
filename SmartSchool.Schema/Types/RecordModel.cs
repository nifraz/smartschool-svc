﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Types
{
    public class RecordModel
    {
        [IsProjected(true)]
        public long? Id { get; set; }

        public DateTime? CreatedTime { get; set; }
        public long? CreatedUserId { get; set; }
        public UserModel? CreatedUser { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public long? LastModifiedUserId { get; set; }
        public UserModel? LastModifiedUser { get; set; }
        public DateTime? DeletedTime { get; set; }
        public long? DeletedUserId { get; set; }
        public UserModel? DeletedUser { get; set; }
    }
}
