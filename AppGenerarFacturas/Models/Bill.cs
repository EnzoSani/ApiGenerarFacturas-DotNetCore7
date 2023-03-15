using System.ComponentModel.DataAnnotations;

namespace AppGenerarFacturas.Models
{
    public class Bill
    {    
        public int Id { get; set; }  
        public DateTime Time { get;set; }
        public decimal Total { get; set; }
        public ICollection<InvoiseLine> InvoiseLines { get; set; } = new List<InvoiseLine>();
        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;


    }
}
