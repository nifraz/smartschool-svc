using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Enums
{
    public enum EnrollmentStatus : byte
    {
        Unknown = 0,
        Active = 1,         // Currently enrolled
        Left = 2,           // Has left the institution
        Rejoined = 3,       // Rejoined after leaving
        Completed = 4,      // Completed studies (applies to students)
        Retired = 5,        // Retired (alternative completion, e.g., teachers/principals)
        Cancelled = 6,      // Enrollment canceled
        Resigned = 7        // Specifically resigned from the position
    }
}
