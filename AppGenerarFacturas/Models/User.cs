using System.ComponentModel.DataAnnotations;

namespace AppGenerarFacturas.Models
{
    public class User
    {
         public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string PasswordHash { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public string? LastName { get; set; } 
        [EmailAddress]
        public string? Email { get; set; } 
        [Required]
        public string Password { get; set; } = null!;
        public ICollection<Company> Companies { get; set; } = new List<Company>();



    }
}
