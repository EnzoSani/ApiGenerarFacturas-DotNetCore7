using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AppGenerarFacturas.Services;
using AppGenerarFacturas.Services.contracts;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppGenerarFacturas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBillService _billService;
        private readonly IMapper _mapper;

        public BillsController(ApplicationDBContext context, IMapper mapper, IBillService billService)
        {
            _context = context;
            _mapper = mapper;
            _billService = billService;
        }

        [HttpGet("getBillsList")]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBills()
        {
            return await _billService.getBills();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBill(int id)
        {
            return await _billService.GetBill(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBill(int id, Bill updateBill)
        {
            return await _billService.UpdateBill(id, updateBill);
        }

        [HttpPost]
        public async Task<ActionResult<Bill>> PostBill(BillCreationDTO billCreacion)
        {
            var bill = await _billService.CreateBill(billCreacion);

            return CreatedAtAction("GetBill", new { id = bill.Id }, bill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBill(int id)
        {
            var success = await _billService.DeleteBill(id);

            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
