using AppGenerarFacturas.Models;
using Microsoft.EntityFrameworkCore;

namespace AppGenerarFacturas.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public  DbSet<Bill> Bills { get; set; }
        public DbSet<InvoiseLine> InvoiseLines { get; set;}
    }  
}
