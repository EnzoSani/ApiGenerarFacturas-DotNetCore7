using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppGenerarFacturas.Services.contracts
{
    public interface IInvoiseLineService
    {
        Task<InvoiseLine> CreateInvoiseLine(InvoiseLineCreationDTO invoiseLineCreacion);
        Task<bool> DeleteInvoiseLine(int id);
        Task<ActionResult<IEnumerable<InvoiseLine>>> getInvoiseLines();
        Task<ActionResult<InvoiseLine>> GetInvoiseLine(int id);
        Task<IActionResult> UpdateInvoiseLine(int id, InvoiseLine updatedInvosieLine);
    }
}
