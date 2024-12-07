using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Classes
{
    public class Age
    {
        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }

        public string ShortString
        {
            get
            {
                return $"{Years}y-{Months}m-{Days}d";
            }
        }
        public string LongString
        {
            get
            {
                return $"{Years} {nameof(Years)}, {Months} {nameof(Months)}, {Days} {nameof(Days)}";
            }
        }
    }
}
