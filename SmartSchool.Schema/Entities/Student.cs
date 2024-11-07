using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchool.Schema.Entities
{
    public class Student : AbstractRecord
    {
        //one
        [ForeignKey(nameof(Person))]
        public long PersonId { get; set; }
        public Person Person { get; set; }

        //many
        [InverseProperty(nameof(SchoolStudentEnrollment.Student))]
        public ICollection<SchoolStudentEnrollment> StudentAdmissions { get; set; } = [];

    }

}
