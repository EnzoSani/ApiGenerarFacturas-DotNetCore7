using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AutoMapper;

namespace AppGenerarFacturas.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<UserCreacionDTO, User>();
        
        }
    }
}
