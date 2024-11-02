using Microsoft.EntityFrameworkCore;
using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    [Index(nameof(CensusNo), IsUnique = true)]
    public class School : AbstractRecord
    {
        public string CensusNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public SchoolType Type { get; set; }

        //one
        [ForeignKey(nameof(Division))]
        public int DivisionId { get; set; }
        public Division Division { get; set; }

        //many
        [InverseProperty(nameof(SchoolStudentAdmission.School))]
        public ICollection<SchoolStudentAdmission> StudentAdmissions { get; set; } = [];
        [InverseProperty(nameof(Class.School))]
        public ICollection<Class> Classes { get; set; } = [];
    }
}
