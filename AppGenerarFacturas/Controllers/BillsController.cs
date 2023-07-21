using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AppGenerarFacturas.Services;
using AppGenerarFacturas.Services.contracts;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

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
        public async Task<ActionResult<IEnumerable<BillDTO>>> GetBills()
        {
            var billsList = await _billService.getBills();
            var billsListDTO = _mapper.Map<IEnumerable<BillDTO>>(billsList);
            return Ok(billsListDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBill(int id)
        {
            try
            {
                var bill = await _billService.GetBill(id);
                if(bill == null)
                {
                    return NotFound();
                }

                var billDTO = _mapper.Map<BillDTO>(bill);
                return Ok(billDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBill(int id, BillDTO billDto)
        {
            try
            {
                var bill = _mapper.Map<Bill>(billDto);
                if(id != bill.Id)
                {
                    return BadRequest();
                }
                var billItem = await _billService.GetBill(id);

                if(billItem == null)
                {
                    return BadRequest();
                }

                await _billService.UpdateBill(bill);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateBill([FromBody] BillDTO billDto)
        {
            try
            {
                var bill = _mapper.Map<Bill>(billDto);
                bill.Time = DateTime.Now;
                bill = await _billService.CreateBill(bill);
                var billItemDTO = _mapper.Map<BillDTO>(bill);

                return CreatedAtAction(nameof(GetBills), new { id = billItemDTO.Id }, billItemDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBill(int Id)
        {
            try
            {
                var bill = await _billService.GetBill(Id);
                if(bill == null)
                {
                    return NotFound();
                }
                await _billService.DeleteBill(bill);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

    }
}
