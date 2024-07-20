using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Types
{
    public class StudentInput
    {
        public string? StudentId { get; set; }
        public string? FullName { get; set; }
        public string? NickName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? MobileNo { get; set; }
    }
}
