using System.ComponentModel.DataAnnotations;

namespace AppGenerarFacturas.Models
{
    public class User
    {
         public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        public ICollection<Company> Companies { get; set; } = new List<Company>();



    }
}
