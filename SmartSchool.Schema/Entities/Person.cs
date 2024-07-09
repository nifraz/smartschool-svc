using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Person : Entity
    {
        [Required]
        public string FullName { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
    }
}
