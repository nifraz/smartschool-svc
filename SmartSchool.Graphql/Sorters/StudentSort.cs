using HotChocolate.Data.Sorting;
using SmartSchool.Graphql.Models;

namespace SmartSchool.Graphql.Sorters
{
    public class StudentSort : SortInputType<StudentModel>
    {
        protected override void Configure(ISortInputTypeDescriptor<StudentModel> descriptor)
        {
            //descriptor.Ignore(x => x.Id);
            //descriptor.Field(x => x.Name).Name("CourseName");

            base.Configure(descriptor);
        }
    }
}
