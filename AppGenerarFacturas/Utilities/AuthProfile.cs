using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AutoMapper;

namespace AppGenerarFacturas.Utilities
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<UserCreacionDTO, User>();
            CreateMap<UserCredentials, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName));
            CreateMap<User, UserResponse>();
        }
        
    }
}
