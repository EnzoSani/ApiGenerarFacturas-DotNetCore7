using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;

namespace JwtWebApiDotNet7.Services
{
    public interface IAuthService
    {
        Task<string> CreateToken(UserResponse user);
    }
}
