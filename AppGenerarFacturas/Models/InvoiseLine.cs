using System.ComponentModel.DataAnnotations;

namespace AppGenerarFacturas.Models
{
    public class InvoiseLine
    {
        
        public int Id { get; set; }
        [StringLength(280)]
        public string Description { get; set; } = string.Empty;
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public int BillId { get; set; }
        public Bill Bill { get; set; } = null!;
    }
}
