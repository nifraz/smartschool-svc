using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public interface IEntity
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }

    }
}
