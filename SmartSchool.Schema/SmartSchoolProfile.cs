using AutoMapper;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Models;
using SmartSchool.Schema.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Person, PersonType>();
            CreateMap<PersonInput, Person>();

            CreateMap<Student, StudentType>();
            CreateMap<StudentInput, Student>();

            CreateMap<UserRegisterRequest, Person>();
            CreateMap<UserRegisterRequest, User>();
        }
    }
}
