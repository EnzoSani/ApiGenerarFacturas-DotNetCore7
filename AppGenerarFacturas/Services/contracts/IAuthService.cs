using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;


namespace AppGenerarFacturas.Services.contracts
{
    public interface IAuthService
    {
        Task<string> CreateToken(UserResponse user);
    }
}
