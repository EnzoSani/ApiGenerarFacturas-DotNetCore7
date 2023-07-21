using System.ComponentModel.DataAnnotations;

namespace AppGenerarFacturas.Models
{
    public class InvoiseLine
    {
        
        public int Id { get; set; }
        [StringLength(280)]
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public Bill Bill { get; set; } = null!;

    }
}
