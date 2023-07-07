using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AppGenerarFacturas.Services.contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ActionResult<IEnumerable<InvoiseLine>>> getInvoiseLines()
        {
            var invoiseLine = await _context.InvoiseLines.ToListAsync();

            if (invoiseLine == null)
            {
                return new NotFoundObjectResult(null);
            }

            return invoiseLine;
        }

        public async Task<ActionResult<InvoiseLine>> GetInvoiseLine(int id)
        {
            if (_context.InvoiseLines == null)
            {
                return new NotFoundObjectResult(null);
            }
            var invoiseLine = await _context.InvoiseLines.FindAsync(id);

            if (invoiseLine == null)
            {
                return new NotFoundObjectResult(null);
            }

            return invoiseLine;
        }

        public async Task<IActionResult> UpdateInvoiseLine(int id, InvoiseLine updatedInvosieLine)
        {
            if (id != updatedInvosieLine.Id)
            {
                return new BadRequestResult();
            }

            _context.Entry(updatedInvosieLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiseLineExists(id))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }
            return new NoContentResult();
        }

        public async Task<InvoiseLine> CreateInvoiseLine(InvoiseLineCreationDTO invoiseLineCreacion)
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

        private bool InvoiseLineExists(int id)
        {
            return (_context.InvoiseLines?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
