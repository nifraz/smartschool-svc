using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using SmartSchool.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Types
{
    public class PersonModel : RecordModel
    {
        public string? FullName { get; set; }
        public string? ShortName { get; set; }
        public string? Nickname { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? BcNo { get; set; }
        public Sex? Sex { get; set; }
        public string? NicNo { get; set; }
        public string? PassportNo { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }

        public AgeModel? Age
        {
            get
            {
                return DateOfBirth != null
                    ? CalculateExactAge(DateOfBirth.Value)
                    : null;
            }
        }
        //public ICollection<Relationship> Relationships { get; set; } = [];

        private static AgeModel CalculateExactAge(DateOnly dateOfBirth)
        {
            var (years, months, days) = dateOfBirth.GetAge(DateTime.Today);

            return new AgeModel
            {
                Years = years,
                Months = months,
                Days = days,
            };
        }

    }
}
