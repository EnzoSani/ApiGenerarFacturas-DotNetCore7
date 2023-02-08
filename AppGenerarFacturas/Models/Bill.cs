using System.ComponentModel.DataAnnotations;

namespace AppGenerarFacturas.Models
{
    public class Bill
    {
        [Required]
        public int Id { get; set; }
        [Required] 
        public DateTime Time { get;set; }
        [Required]
        public decimal Total { get; set; }
        

    }
}
