using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppGenerarFacturas.Services.contracts
{
    public interface IInvoiseLineService
    {
        Task<InvoiseLine> CreateInvoiseLine(InvoiseLineDTO invoiseLineCreacion);
        Task<bool> DeleteInvoiseLine(int id);
        Task<IEnumerable<InvoiseLine>> GetInvoiseLinesOfaBill(int id);
        Task<IEnumerable<InvoiseLine>> getInvoiseLines();
        Task<InvoiseLine> GetInvoiceLine(int id);
        Task UpdateInvoiceLine(InvoiseLine invoiseLine);
        //Task<InvoiseLine> GetInvoiseLinesOfaBill(int billId, int invoiceLineId);
    }
}
