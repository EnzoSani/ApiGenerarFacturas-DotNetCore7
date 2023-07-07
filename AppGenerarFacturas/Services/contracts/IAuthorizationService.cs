using AppGenerarFacturas.Models.Custom;

namespace AppGenerarFacturas.Services.contracts
{
    public interface IAuthorizationService
    {
        Task<AuthorizationService> ReturnToken(AuthorizationService response);
    }
}
