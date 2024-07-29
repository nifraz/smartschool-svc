using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Enums
{
    /// <summary>
    /// ISO/IEC 5218 Human Sex
    /// </summary>
    public enum SexType : byte
    {
        NotKnown = 0,
        Male = 1,
        Female = 2,
        NotApplicable = 9,
    }
}
