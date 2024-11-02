using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Enums
{
    public enum StudentAdmissionStatus : byte
    {
        Unknown = 0,
        Active = 1,     // When the student is currently enrolled
        Left = 2,       // When the student has left the school
        Rejoined = 3,    // When the student has rejoined after leaving
        Completed = 4,    // When the student has completed the studies
        Cancelled = 5,
    }
}
