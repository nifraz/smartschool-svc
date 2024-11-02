using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Language
    {
        [Key]
        [MaxLength(2)]
        [Required]
        public string Code { get; set; }  // ISO 639-1 two-letter code

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }  // Full name of the language

        [MaxLength(5)]
        public string? IetfTag { get; set; }  // Optional: IETF language tag for regional variants (e.g., en-US)

        public ICollection<Class> Classes { get; set; } = [];
    }
}
