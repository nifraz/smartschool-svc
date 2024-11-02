using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Enums
{
    public enum RecordStatus : byte
    {
        Unknown = 0,
        Created = 1,
        Modified = 2,
        Deleted = 3,
    }
}
