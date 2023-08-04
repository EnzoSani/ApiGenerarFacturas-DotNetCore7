using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AppGenerarFacturas.Services.contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppGenerarFacturas.Services
{
    public class InvoiseLineService : IInvoiseLineService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public InvoiseLineService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InvoiseLine>> getInvoiseLines()
        {
            var invoiseLines = await _context.InvoiseLines.ToListAsync();

            return invoiseLines;
        }

        public async Task<IEnumerable<InvoiseLine>> GetInvoiseLinesOfaBill(int id)
        {        
            var invoiseLines = await _context.InvoiseLines.Where(il => il.BillId == id).ToListAsync();

            return invoiseLines;
        }

        public async Task UpdateInvoiceLine(InvoiseLine invoiseLine)
        {
            var invoiceLineItem = await _context.InvoiseLines.FirstOrDefaultAsync(x => x.Id == invoiseLine.Id);

            if (invoiceLineItem != null)
            {
                invoiceLineItem.Description = invoiseLine.Description;
                invoiceLineItem.Price = invoiseLine.Price;
                invoiceLineItem.Amount = invoiseLine.Amount;
                invoiceLineItem.Bill = invoiseLine.Bill;
                invoiceLineItem.BillId = invoiseLine.BillId;

                await _context.SaveChangesAsync();
            }

        }

        public async Task<InvoiseLine> CreateInvoiseLine(InvoiseLineDTO invoiseLineCreacion)
        {
            if (_context.InvoiseLines == null)
            {
                throw new Exception("Entity set 'ApplicationDBContext.Users' is null.");
            }

            var invoiseLine = _mapper.Map<InvoiseLine>(invoiseLineCreacion);
            _context.InvoiseLines.Add(invoiseLine);
            await _context.SaveChangesAsync();

            return invoiseLine;
        }

        public async Task<bool> DeleteInvoiseLine(int id)
        {
            var invoiseLine = await _context.InvoiseLines.FindAsync(id);
            if (invoiseLine == null)
            {
                return false;
            }

            _context.InvoiseLines.Remove(invoiseLine);
            await _context.SaveChangesAsync();

            return true;
        }

        //public async Task<InvoiseLine> GetInvoiseLinesOfaBill(int billId, int invoiceLineId)
        //{
        //    var bill = await _context.Bills.FindAsync(billId);

        //    var invoiceLine = bill.InvoiseLines.FirstOrDefault(x => x.Id == invoiceLineId);

        //    return invoiceLine;

        //}

        public async Task<InvoiseLine> GetInvoiceLine(int id)
        {

            var invoiceLine = await _context.InvoiseLines.FirstOrDefaultAsync(b => b.Id == id);

            return invoiceLine;
        }

        private bool InvoiseLineExists(int id)
        {
            return (_context.InvoiseLines?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
