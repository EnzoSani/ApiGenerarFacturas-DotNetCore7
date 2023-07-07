using System.ComponentModel.DataAnnotations;

namespace AppGenerarFacturas.DTOS
{
    public class CompanyCreationDTO
    {
        [Required, StringLength(150)]
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(150)]
        public string Direccion { get; set; } = null!;
        [Required, StringLength(150)]
        public int TelephoneNumber { get; set; }
    }
}
