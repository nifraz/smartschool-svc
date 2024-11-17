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
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.MobileNo, opt => opt.MapFrom(src => src.Person.MobileNo))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Person.Email))
                ;
        }
    }
}
