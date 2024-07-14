﻿using HotChocolate.Data.Sorting;
using SmartSchool.Schema.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Sorters
{
    public class StudentSort : SortInputType<StudentType>
    {
        protected override void Configure(ISortInputTypeDescriptor<StudentType> descriptor)
        {
            //descriptor.Ignore(x => x.Id);
            //descriptor.Field(x => x.Name).Name("CourseName");

            base.Configure(descriptor);
        }
    }
}
