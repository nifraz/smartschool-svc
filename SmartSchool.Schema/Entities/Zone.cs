using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Zone
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string SinhalaName { get; set; }
        public string TamilName { get; set; }

        //one
        [ForeignKey(nameof(District))]
        public int DistrictId { get; set; }
        public District District { get; set; }

        //many
        [InverseProperty(nameof(Division.Zone))]
        public ICollection<Division> Divisions { get; set; } = [];
    }
}
