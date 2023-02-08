using System.ComponentModel.DataAnnotations;

namespace AppGenerarFacturas.Models
{
    public class InvoiseLine
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(280)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int Amount { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
