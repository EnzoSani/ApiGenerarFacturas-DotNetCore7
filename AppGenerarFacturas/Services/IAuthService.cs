using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;


namespace AppGenerarFacturas.Services
{
    public interface IAuthService
    {
        Task<string> CreateToken(UserResponse user);
    }
}
