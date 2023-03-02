using AppGenerarFacturas.Models;

namespace AppGenerarFacturas.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUserList();
        
    }
}
