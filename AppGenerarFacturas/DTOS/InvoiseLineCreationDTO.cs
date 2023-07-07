namespace AppGenerarFacturas.DTOS
{
    public class InvoiseLineCreationDTO
    {
        public string Description { get; set; } = string.Empty;
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
