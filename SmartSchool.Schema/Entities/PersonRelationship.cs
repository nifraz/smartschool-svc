using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class PersonRelationship : AbstractRecord
    {
        //one
        // Foreign key to the person who is the parent in the relationship
        public long ParentPersonId { get; set; }
        [ForeignKey("ParentPersonId")]
        public Person ParentPerson { get; set; }

        // Foreign key to the person who is the child in the relationship
        public long ChildPersonId { get; set; }
        [ForeignKey("ChildPersonId")]
        public Person ChildPerson { get; set; }

        [Required]
        public HumanRelationship ParentToChildRelationship { get; set; }
    }
}
