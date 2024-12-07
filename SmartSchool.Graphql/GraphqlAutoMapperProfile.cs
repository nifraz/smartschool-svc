using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SmartSchool.Schema.Entities;
using SmartSchool.Graphql.Models;
using SmartSchool.Graphql.Inputs;
using SmartSchool.Schema.Classes;

namespace SmartSchool.Graphql
{
    public class GraphqlAutoMapperProfile : Profile
    {
        public GraphqlAutoMapperProfile()
        {
            //entity to model
            CreateMap<Language, LanguageModel>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name + " (" + src.Code + ")"))
                ;

            CreateMap<User, UserModel>()
                ;
            CreateMap<Person, PersonModel>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.ShortName + " (" + src.Sex.ToString() + " " + src.Age.ShortString + ")"))
                ;
            CreateMap<Age, AgeModel>()
                ;
            CreateMap<PersonRelationship, PersonRelationshipModel>()
                ;
            CreateMap<School, SchoolModel>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name + " (" + src.Location + ")"))
                ;
            CreateMap<AcademicYear, AcademicYearModel>()
                ;
            CreateMap<SchoolStudentEnrollment, SchoolStudentEnrollmentModel>()
                ;
            CreateMap<SchoolStudentEnrollmentRequest, SchoolStudentEnrollmentRequestModel>()
                ;
            CreateMap<SchoolTeacherEnrollment, SchoolTeacherEnrollmentModel>()
                ;
            CreateMap<SchoolTeacherEnrollmentRequest, SchoolTeacherEnrollmentRequestModel>()
               //.ForMember(dest => dest.PersonFullName, opt => opt.MapFrom(src => src.Person.FullName))
               //.ForMember(dest => dest.PersonDateOfBirth, opt => opt.MapFrom(src => src.Person.DateOfBirth))
               //.ForMember(dest => dest.PersonNicNo, opt => opt.MapFrom(src => src.Person.NicNo))
               ;
            CreateMap<SchoolPrincipalEnrollment, SchoolPrincipalEnrollmentModel>()
               ;
            CreateMap<ClassStudentEnrollment, ClassStudentEnrollmentModel>()
               .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.SchoolStudentEnrollment.StudentId))
               ;
            CreateMap<ClassTeacherEnrollment, ClassTeacherEnrollmentModel>()
               ;
            CreateMap<Student, StudentModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Person.FullName))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Person.Age))
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
                ;
            CreateMap<Teacher, TeacherModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Person.FullName))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Person.Age))
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
                ;
            CreateMap<Principal, PrincipalModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Person.FullName))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Person.Age))
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
                ;
            CreateMap<Class, ClassModel>()
                ;

            //input to entity
            CreateMap<PersonInput, Person>()
                ;
            CreateMap<PersonRelationshipInput, PersonRelationship>()
                ;
            CreateMap<SchoolStudentEnrollmentInput, SchoolStudentEnrollment>()
                ;
            CreateMap<SchoolStudentEnrollmentRequestInput, SchoolStudentEnrollmentRequest>()
                ;
            CreateMap<SchoolTeacherEnrollmentInput, SchoolTeacherEnrollment>()
                ;
            CreateMap<SchoolTeacherEnrollmentRequestInput, SchoolTeacherEnrollmentRequest>()
                ;
            //CreateMap<StudentInput, Student>()
            //  ;
        }
    }
}
