using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppGenerarFacturas.Services.contracts
{
    public interface IBillService
    {
        Task<Bill> CreateBill(BillCreationDTO billCreacion);
        Task<bool> DeleteBill(int id);
        Task<ActionResult<Bill>> GetBill(int id);
        Task<ActionResult<IEnumerable<Bill>>> getBills();
        Task<IActionResult> UpdateBill(int id, Bill updatedBill);
    }
}
