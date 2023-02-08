using System.ComponentModel.DataAnnotations;

namespace AppGenerarFacturas.Models
{
    public class User
    {
        [Required]
         public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;



    }
}
