namespace AppGenerarFacturas.DTOS
{
    public class BillDTO
    {
        public int Id { get; set; }
        public string BillNumber { get; set; }
        public DateTime Time { get; set; }
        public decimal Total { get; set; }
        public ICollection<InvoiseLineDTO> InvoiseLines { get; set; } = new List<InvoiseLineDTO>();
        public CompanyDTO Company { get; set; }
    }
}
