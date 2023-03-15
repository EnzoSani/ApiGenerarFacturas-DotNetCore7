using System.ComponentModel.DataAnnotations;

namespace AppGenerarFacturas.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Direccion { get; set; } = null!;
        public int TelephoneNumber { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();

    }
}
