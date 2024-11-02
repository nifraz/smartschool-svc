using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class Province
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SinhalaName { get; set; }
        public string TamilName { get; set; }

        //many
        [InverseProperty(nameof(District.Province))]
        public ICollection<District> Districts { get; set; } = [];

        //[NotMapped]
        //public int Code { get { return Id; } }

        //public override string ToString() => $"{Name} / {SinhalaName} / {TamilName}";
    }
}
