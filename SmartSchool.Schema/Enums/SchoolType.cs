using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Enums
{
    public enum SchoolType : byte
    {
        //NotSet = 0,
        Type1AB = 1, // Schools with GCE Advanced Level (A-Level) classes
        Type1C = 2, // Schools with GCE Advanced Level (A-Level) art and commerce classes
        Type2 = 3, // Schools with classes up to year 11 (GCE O-Level)
        Type3i = 4, // Elementary schools with classes up to year 8
        Type3ii = 5, // Primary schools with classes up to year 5
    }
}
