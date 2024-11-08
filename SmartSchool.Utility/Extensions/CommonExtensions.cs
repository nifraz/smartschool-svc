using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Utility.Extensions
{
    public static class CommonExtensions
    {
        public static (int years, int months, int days) GetAge(this DateOnly dateOfBirth, DateTime onDate)
        {
            int years = onDate.Year - dateOfBirth.Year;
            int months = onDate.Month - dateOfBirth.Month;
            int days = onDate.Day - dateOfBirth.Day;

            // Adjust for negative days or months
            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(onDate.Year, onDate.AddMonths(-1).Month);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            return (years, months, days);
        }
    }
}
