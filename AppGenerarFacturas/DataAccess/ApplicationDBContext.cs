using AppGenerarFacturas.Models;
using Microsoft.EntityFrameworkCore;

namespace AppGenerarFacturas.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        DbSet<User> Users { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Bill> Bills { get; set; }
        DbSet<InvoiseLine> InvoiseLines { get; set;}
    }  
}
