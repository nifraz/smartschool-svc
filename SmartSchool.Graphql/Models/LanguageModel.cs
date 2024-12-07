using SmartSchool.Schema.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Graphql.Models
{
    public class LanguageModel : AbstractRecordModel
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? IetfTag { get; set; }

        public ICollection<ClassModel> RecentClasses { get; set; } = [];
    }
}
