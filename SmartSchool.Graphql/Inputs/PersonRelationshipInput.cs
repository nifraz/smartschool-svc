using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Graphql.Inputs
{
    public class PersonRelationshipInput : AbstractRecordInput
    {
        [Required]
        public long Person1Id { get; set; }
        [Required]
        public HumanRelationship Person1Relationship { get; set; }

        [Required]
        public long Person2Id { get; set; }
        [Required]
        public HumanRelationship Person2Relationship { get; set; }
    }
}
