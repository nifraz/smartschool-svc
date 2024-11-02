using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string SinhalaName { get; set; }
        public string TamilName { get; set; }

        //one
        [ForeignKey(nameof(Province))]
        public int ProvinceId { get; set; }
        public Province Province { get; set; }

        //many
        [InverseProperty(nameof(Zone.District))]
        public ICollection<Zone> Zones { get; set; } = [];
    }
}
