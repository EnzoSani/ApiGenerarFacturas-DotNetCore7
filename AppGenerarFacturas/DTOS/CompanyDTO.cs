namespace AppGenerarFacturas.DTOS
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Direccion { get; set; } = null!;
        public string TelephoneNumber { get; set; }
    }
}
