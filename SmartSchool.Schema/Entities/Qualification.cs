using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Qualification
    {
        [Key]
        [Required]
        public byte Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }

        //many
        [InverseProperty(nameof(PersonQualification.Qualification))]
        public ICollection<PersonQualification> PersonQualifications { get; set; } = [];

    }
}
