using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Graphql.Models
{
    public class DivisionModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? SinhalaName { get; set; }
        public string? TamilName { get; set; }
        public string? Label { get; set; }
    }
}
