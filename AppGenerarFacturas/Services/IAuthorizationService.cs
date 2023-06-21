using AppGenerarFacturas.Models.Custom;

namespace AppGenerarFacturas.Services
{
    public interface IAuthorizationService
    {
        Task<AuthorizationService> ReturnToken(AuthorizationService response);
    }
}
