using System.ComponentModel.DataAnnotations;

namespace AppGenerarFacturas.Models
{
    public class Company
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Direccion { get; set; } = null!;
        [Required]
        public int TelephoneNumber { get; set; }
        public User Users { get; set; }
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();

    }
}
