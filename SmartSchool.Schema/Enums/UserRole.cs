using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Enums
{
    public enum UserRole : byte
    {
        Guest = 1,
        Guardian = 2,
        Student = 3,
        Teacher = 4,
        Staff = 5,
        Principal = 6,

    }
}
