using System.ComponentModel.DataAnnotations;

namespace AppGenerarFacturas.DTOS
{
  
    public class UserCreacionDTO
    {
        [Required, StringLength (150)]
        public string Name { get; set; } = null!;
        [Required, StringLength(150)]
        public string LastName { get; set; } = null!;
        [Required, StringLength(150)]
        public string Password { get; set; } = null!;
        [Required, StringLength(150)]
        public string Email { get; set; } = null!;
    }
}
