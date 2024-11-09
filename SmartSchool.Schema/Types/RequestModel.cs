using SmartSchool.Schema.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Types
{
    public class RequestModel : RecordModel
    {
        public RequestStatus? Status { get; set; }
        public string? Reason { get; set; }
    }
}
