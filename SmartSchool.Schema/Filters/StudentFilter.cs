using HotChocolate.Data.Filters;
using SmartSchool.Schema.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Filters
{
    public class StudentFilter : FilterInputType<StudentModel>
    {
        protected override void Configure(IFilterInputTypeDescriptor<StudentModel> descriptor)
        {
            //descriptor.Ignore(x => x.Students);
            base.Configure(descriptor);
        }
    }
}
