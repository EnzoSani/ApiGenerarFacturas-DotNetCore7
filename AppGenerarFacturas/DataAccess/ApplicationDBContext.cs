using Microsoft.EntityFrameworkCore;

namespace AppGenerarFacturas.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
    }  
}
