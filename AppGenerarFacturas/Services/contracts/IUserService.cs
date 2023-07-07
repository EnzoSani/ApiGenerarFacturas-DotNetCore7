using AppGenerarFacturas.Models;

namespace AppGenerarFacturas.Services.contracts
{
    public interface IUserService
    {
        IEnumerable<User> GetUserList();

    }
}
