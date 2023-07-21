using System.ComponentModel.DataAnnotations;

namespace AppGenerarFacturas.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Direccion { get; set; } = null!;
        public string TelephoneNumber { get; set; }
        public User Admin { get; set; } = null!;
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();

    }
}
