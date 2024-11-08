using AutoMapper;
using HotChocolate;
using SmartSchool.Schema.DataLoaders;
using SmartSchool.Schema.Entities;

namespace SmartSchool.Schema.Types
{
    public class TeacherModel : PersonModel
    {
        public IEnumerable<SchoolTeacherEnrollmentModel> SchoolTeacherEnrollments { get; set; } = [];
        
    }
}
