namespace AppGenerarFacturas.DTOS
{
    public class InvoiseLineDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public int BillId { get; set; }
    }
}
