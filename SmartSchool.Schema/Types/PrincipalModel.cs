using AutoMapper;
using HotChocolate;
using SmartSchool.Schema.DataLoaders;
using SmartSchool.Schema.Entities;

namespace SmartSchool.Schema.Types
{
    public class PrincipalModel : PersonModel
    {
        public IEnumerable<SchoolPrincipalEnrollmentModel> SchoolPrincipalEnrollments { get; set; } = [];
    }
}
