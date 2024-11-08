using AutoMapper;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Inputs;
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
            //entity to type
            CreateMap<Person, PersonModel>()
                ;
            CreateMap<School, SchoolModel>()
                ;
            CreateMap<SchoolStudentEnrollment, SchoolStudentEnrollmentModel>()
                .ForMember(dest => dest.SchoolName, opt => opt.MapFrom(src => src.School.Name))
                ;
            CreateMap<SchoolStudentEnrollmentRequest, SchoolStudentEnrollmentRequestModel>()
                //.ForMember(dest => dest.PersonFullName, opt => opt.MapFrom(src => src.Person.FullName))
                //.ForMember(dest => dest.PersonDateOfBirth, opt => opt.MapFrom(src => src.Person.DateOfBirth))
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

            //inputs to entity
            CreateMap<PersonInput, Person>()
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

            //other
            CreateMap<UserRegisterRequest, Person>()
                ;
            CreateMap<UserRegisterRequest, User>()
                ;
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

                //.ForMember(dest => dest.IsGuardian, opt => opt.MapFrom(src => src.Person.Guardian != null))
                .ForMember(dest => dest.IsStudent, opt => opt.MapFrom(src => src.Person.Student != null))
                //.ForMember(dest => dest.IsStaff, opt => opt.MapFrom(src => src.Person.Staff != null))
                .ForMember(dest => dest.IsTeacher, opt => opt.MapFrom(src => src.Person.Teacher != null))
                .ForMember(dest => dest.IsPrincipal, opt => opt.MapFrom(src => src.Person.Principal != null))

                ////.ForMember(dest => dest.IsGuardian, opt => opt.MapFrom(src => src.Person.Guardian != null))
                //.ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Person.Student.Id))
                ////.ForMember(dest => dest.IsStaff, opt => opt.MapFrom(src => src.Person.Staff != null))
                //.ForMember(dest => dest.IsTeacher, opt => opt.MapFrom(src => src.Person.Teacher != null))
                //.ForMember(dest => dest.IsPrincipal, opt => opt.MapFrom(src => src.Person.Principal != null))
                ;
        }
    }
}
