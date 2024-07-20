using AutoMapper;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile() 
        {
            CreateMap<Student, StudentType>();

            CreateMap<StudentInput, Student>()
                .ForMember(x => x.Id, o => o.Ignore());
        }
    }
}
