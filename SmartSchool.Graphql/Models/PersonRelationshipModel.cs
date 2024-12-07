using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Graphql.Models
{
    public class PersonRelationshipModel : AbstractRecordModel
    {
        public long? Person1Id { get; set; }
        public PersonModel? Person1 { get; set; }
        public HumanRelationship? Person1Relationship { get; set; }

        public long? Person2Id { get; set; }
        public PersonModel? Person2 { get; set; }
        public HumanRelationship? Person2Relationship { get; set; }

    }
}
