using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.Models;

namespace AppGenerarFacturas.Services
{
    public  class UserService : IUserService
    {
        private readonly ApplicationDBContext _DbContext;
        public UserService(ApplicationDBContext DbContext)
        {
            _DbContext = DbContext;
        }
        public IEnumerable<User> GetUserList()
        {
            var userList = _DbContext.Users.ToList();
            return userList;
        }
    }
}
