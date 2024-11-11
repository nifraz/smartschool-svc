using AutoMapper;
using SmartSchool.Schema.Entities;
using SmartSchool.Service.Models;

namespace SmartSchool.Api
{
    public class ServiceAutoMapperProfile : Profile
    {
        public ServiceAutoMapperProfile()
        {
            CreateMap<RegisterRequest, Person>()
                ;
            CreateMap<RegisterRequest, User>()
                ;
            CreateMap<User, RegisterResponse>()
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

            CreateMap<User, VerifyEmailResponse>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Person.Email))
                ;
        }
    }
}
