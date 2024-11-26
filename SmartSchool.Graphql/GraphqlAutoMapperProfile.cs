using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SmartSchool.Schema.Entities;
using SmartSchool.Graphql.Models;
using SmartSchool.Graphql.Inputs;

namespace SmartSchool.Graphql
{
    public class GraphqlAutoMapperProfile : Profile
    {
        public GraphqlAutoMapperProfile()
        {
            //entity to model

            CreateMap<User, UserModel>()
                ;
            CreateMap<Person, PersonModel>()
                ;
            CreateMap<PersonRelationship, PersonRelationshipModel>()
                ;
            CreateMap<School, SchoolModel>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name + " (" + src.Location + ")"))
                ;
            CreateMap<AcademicYear, AcademicYearModel>()
                ;
            CreateMap<SchoolStudentEnrollment, SchoolStudentEnrollmentModel>()
                .ForMember(dest => dest.SchoolName, opt => opt.MapFrom(src => src.School.Name))
                .ForMember(dest => dest.StudentFullName, opt => opt.MapFrom(src => src.Student.Person.FullName))
                ;
            CreateMap<SchoolStudentEnrollmentRequest, SchoolStudentEnrollmentRequestModel>()
                .ForMember(dest => dest.SchoolName, opt => opt.MapFrom(src => src.School.Name))
                .ForMember(dest => dest.PersonFullName, opt => opt.MapFrom(src => src.Person.FullName))
                ;
            CreateMap<SchoolTeacherEnrollment, SchoolTeacherEnrollmentModel>()
                .ForMember(dest => dest.SchoolName, opt => opt.MapFrom(src => src.School.Name))
                ;
            CreateMap<SchoolTeacherEnrollmentRequest, SchoolTeacherEnrollmentRequestModel>()
               //.ForMember(dest => dest.PersonFullName, opt => opt.MapFrom(src => src.Person.FullName))
               //.ForMember(dest => dest.PersonDateOfBirth, opt => opt.MapFrom(src => src.Person.DateOfBirth))
               //.ForMember(dest => dest.PersonNicNo, opt => opt.MapFrom(src => src.Person.NicNo))
               ;
            CreateMap<SchoolPrincipalEnrollment, SchoolPrincipalEnrollmentModel>()
                .ForMember(dest => dest.SchoolName, opt => opt.MapFrom(src => src.School.Name))
               ;
            CreateMap<ClassStudentEnrollment, ClassStudentEnrollmentModel>()
               .ForMember(dest => dest.AcademicYear, opt => opt.MapFrom(src => src.AcademicYear.Year))
               .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.SchoolStudentEnrollment.StudentId))
               .ForMember(dest => dest.StudentFullName, opt => opt.MapFrom(src => src.SchoolStudentEnrollment.Student.Person.FullName))
               ;
            CreateMap<ClassTeacherEnrollment, ClassTeacherEnrollmentModel>()
               .ForMember(dest => dest.AcademicYear, opt => opt.MapFrom(src => src.AcademicYear.Year))
               ;
            CreateMap<Student, StudentModel>()
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
                ;
            CreateMap<Teacher, TeacherModel>()
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
                ;
            CreateMap<Principal, PrincipalModel>()
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
                ;
            CreateMap<Class, ClassModel>()
                .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.Language.Name))
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
