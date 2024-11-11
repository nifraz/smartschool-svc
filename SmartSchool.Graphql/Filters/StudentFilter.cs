using HotChocolate.Data.Filters;
using SmartSchool.Graphql.Models;

namespace SmartSchool.Graphql.Filters
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
