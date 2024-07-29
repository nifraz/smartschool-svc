using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchool.Schema.Entities
{
    public class Student : Person
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        // foreign
        //public long PersonId { get; set; }
        //public Person Person { get; set; }
        //public ICollection<Admission> SchoolAdmissions { get; set; } = [];
    }

}
