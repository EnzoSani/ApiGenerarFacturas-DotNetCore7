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
        private readonly IBillService _billService;
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _context;

        public InvoiseLineController(IInvoiseLineService invoiseLineService, IMapper mapper, IBillService billService, ApplicationDBContext context)
        {
            _invoiseLineService = invoiseLineService;
            _mapper = mapper;
            _billService = billService;
            _context = context;
        }

        [HttpGet("getInvoiseLineList")]
        public async Task<ActionResult<IEnumerable<InvoiseLineDTO>>> GetInvoiseLines()
        {
            var invoiseLineList = await _invoiseLineService.getInvoiseLines();
            var invoiseLineListDTO = _mapper.Map<IEnumerable<InvoiseLineDTO>>(invoiseLineList);
            return Ok(invoiseLineListDTO);
        }

        [HttpGet("getInvoiseLines/{id}")]
        public async Task<ActionResult<IEnumerable<InvoiseLineDTO>>> GetInvoiseLine(int id)
        {
            try
            {
                var invoiseLines = await _invoiseLineService.GetInvoiseLinesOfaBill(id);
                if(invoiseLines == null)
                {
                    return NotFound();
                }

                var invoiseLineDTOs = _mapper.Map<IEnumerable<InvoiseLineDTO>>(invoiseLines);
                return Ok(invoiseLineDTOs);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceLine(int id, InvoiseLineDTO invoiseLineDTO)
        {
            try
            {
                var invoiseLine = _mapper.Map<InvoiseLine>(invoiseLineDTO);
                if (id != invoiseLine.Id)
                {
                    return BadRequest();
                }
                var invoiseLineItem = await _invoiseLineService.GetInvoiceLine(id);

                if (invoiseLineItem == null)
                {
                    return BadRequest();
                }

                await _invoiseLineService.UpdateInvoiceLine(invoiseLine);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        //var invoiceLineItem = _mapper.Map<InvoiseLine>(invoiceLineDTO);

        [HttpPost("addInvoiceLines/{billId}")]
        public async Task<IActionResult> Post(InvoiseLineDTO invoiseLineDto, int billId)
        {
            try
            {
                var invoiseLine = _mapper.Map<InvoiseLine>(invoiseLineDto);

                // Busca el bill por su Id
                var bill = await _billService.GetBillById(billId);
                if (bill == null)
                {
                    return NotFound("El bill con el Id proporcionado no existe.");
                }

                // Agrega la mascota a la lista de mascotas del animal
                bill.InvoiseLines.Add(invoiseLine);

                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();

                var invoiseLineItemDto = _mapper.Map<InvoiseLineDTO>(invoiseLine);

                return CreatedAtAction("GetInvoiseLine", new { id = invoiseLineItemDto.Id }, invoiseLineItemDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteInvoiceLine/{id}")]
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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetInvoiceLine(int id)
        {
            try
            {
                var invoiceLine = await _invoiseLineService.GetInvoiceLine(id);
                if (invoiceLine == null)
                {
                    return NotFound();
                }

                var invoiceLineDTO = _mapper.Map<InvoiseLineDTO>(invoiceLine);
                return Ok(invoiceLineDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        //[HttpGet("{billId}/addInvoiceLine/{invoiceLineId}")]
        //public async Task<ActionResult<InvoiseLineDTO>> GetInvoiceLine(int billId, int invoiceLineId)
        //{
        //    var invoiceLine = await _invoiseLineService.GetInvoiseLinesOfaBill(billId, invoiceLineId);

        //    if(invoiceLine == null)
        //    {
        //        return NotFound();
        //    }

        //    var invoiceLineDTO = _mapper.Map<InvoiseLineDTO>(invoiceLine);

        //    return Ok(invoiceLineDTO);
        //}

    }
}
