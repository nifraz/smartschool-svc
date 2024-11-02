using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class PersonQualification : AbstractRecord
    {
        public DateOnly? AwardedDate { get; set; }

        //one
        [ForeignKey(nameof(Person))]
        public long PersonId { get; set; }
        public Person Person { get; set; }

        [ForeignKey(nameof(Qualification))]
        public byte QualificationId { get; set; }
        public Qualification Qualification { get; set; }

    }
}
