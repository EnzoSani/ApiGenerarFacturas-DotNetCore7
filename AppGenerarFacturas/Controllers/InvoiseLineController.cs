using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AppGenerarFacturas.Services;
using AppGenerarFacturas.Services.contracts;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppGenerarFacturas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiseLineController : ControllerBase
    {
        private readonly IInvoiseLineService _invoiseLineService;

        public InvoiseLineController(IInvoiseLineService invoiseLineService)
        {
           _invoiseLineService= invoiseLineService;
        }

        [HttpGet("getInvoiseLineList")]
        public async Task<ActionResult<IEnumerable<InvoiseLine>>> GetBills()
        {
            return await _invoiseLineService.getInvoiseLines();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiseLine>> GetInvoiseLine(int id)
        {
            return await _invoiseLineService.GetInvoiseLine(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiseLine(int id, InvoiseLine updateInvoiseLine)
        {
            return await _invoiseLineService.UpdateInvoiseLine(id, updateInvoiseLine);
        }

        [HttpPost]
        public async Task<ActionResult<InvoiseLine>> PostInvoiseLine(InvoiseLineCreationDTO InvoiseLineCreacion)
        {
            var invoiseLine = await _invoiseLineService.CreateInvoiseLine(InvoiseLineCreacion);

            return CreatedAtAction("GetInvoiseLine", new { id = invoiseLine.Id }, invoiseLine);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiseLine(int id)
        {
            var success = await _invoiseLineService.DeleteInvoiseLine(id);

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
