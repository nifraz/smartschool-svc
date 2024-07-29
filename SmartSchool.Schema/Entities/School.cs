using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class School : Record
    {
        [Required]
        public string CensusNo { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Province { get; set; }
        public string? Type { get; set; }
        public string? Zone { get; set; }
        public string? EducationalDivision { get; set; }
        public string? District { get; set; }
        public ICollection<Class> Classes { get; set; } = [];
    }
}
