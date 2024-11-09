using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Enums
{
    public enum RequestStatus : byte
    {
        Unknown = 0,
        Pending = 1,
        Processing = 2,
        OnHold = 3,
        Approved = 4,
        Rejected = 5,
        Cancelled = 6,
    }
}
