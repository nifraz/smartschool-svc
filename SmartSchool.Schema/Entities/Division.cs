using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Division
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string SinhalaName { get; set; }
        public string TamilName { get; set; }

        //one
        [ForeignKey(nameof(Zone))]
        public int ZoneId { get; set; }
        public Zone Zone { get; set; }

        //many
        [InverseProperty(nameof(School.Division))]
        public ICollection<School> Schools { get; set; } = [];
    }
}
