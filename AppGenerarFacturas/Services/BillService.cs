using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AppGenerarFacturas.Services.contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppGenerarFacturas.Services
{
    public class BillService : IBillService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public BillService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<Bill>>> getBills()
        {
            var bills = await _context.Bills.ToListAsync();

            if (bills == null)
            {
                return new NotFoundObjectResult(null);
            }

            return bills;
        }

        public async Task<ActionResult<Bill>> GetBill(int id)
        {
            if (_context.Bills == null)
            {
                return new NotFoundObjectResult(null);
            }
            var bill = await _context.Bills.FindAsync(id);

            if (bill == null)
            {
                return new NotFoundObjectResult(null);
            }

            return bill;
        }

        public async Task<IActionResult> UpdateBill(int id, Bill updatedBill)
        {
            if (id != updatedBill.Id)
            {
                return new BadRequestResult();
            }

            _context.Entry(updatedBill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillExists(id))
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

        public async Task<Bill> CreateBill(BillCreationDTO billCreacion)
        {
            if (_context.Bills == null)
            {
                throw new Exception("Entity set 'ApplicationDBContext.Users' is null.");
            }

            var bill = _mapper.Map<Bill>(billCreacion);
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();

            return bill;
        }

        public async Task<bool> DeleteBill(int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            if (bill == null)
            {
                return false;
            }

            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool BillExists(int id)
        {
            return (_context.Bills?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
