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

            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Person.FullName))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.Person.ShortName))
                .ForMember(dest => dest.Nickname, opt => opt.MapFrom(src => src.Person.Nickname))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.Person.DateOfBirth))
                .ForMember(dest => dest.BcNo, opt => opt.MapFrom(src => src.Person.BcNo))
                .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Person.Sex))
                .ForMember(dest => dest.NicNo, opt => opt.MapFrom(src => src.Person.NicNo))
                .ForMember(dest => dest.PassportNo, opt => opt.MapFrom(src => src.Person.PassportNo))
                .ForMember(dest => dest.MobileNo, opt => opt.MapFrom(src => src.Person.MobileNo))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Person.Email))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Person.Address))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Person.Image))

                .ForMember(dest => dest.IsStudent, opt => opt.MapFrom(src => src.Person.Student != null))
                //.ForMember(dest => dest.IsGuardian, opt => opt.MapFrom(src => src.Person.Guardian != null))
                //.ForMember(dest => dest.IsStaff, opt => opt.MapFrom(src => src.Person.Staff != null))
                .ForMember(dest => dest.IsTeacher, opt => opt.MapFrom(src => src.Person.Teacher != null))
                .ForMember(dest => dest.IsPrincipal, opt => opt.MapFrom(src => src.Person.Principal != null))
                ;
        }
    }
}
