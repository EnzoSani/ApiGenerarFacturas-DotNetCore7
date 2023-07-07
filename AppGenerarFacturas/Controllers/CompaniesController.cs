using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AppGenerarFacturas.Services;
using AppGenerarFacturas.Services.contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AppGenerarFacturas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;

        public CompaniesController(ApplicationDBContext context, IMapper mapper, ICompanyService companyService)
        {
            _context = context;
            _mapper = mapper;
            _companyService = companyService;
        }

        [HttpGet("getCompaniesList")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
           return await _companyService.getCompanies();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompanies(int id)
        {
            return await _companyService.GetCompany(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company updateCompany)
        {
            return await _companyService.UpdateCompany(id, updateCompany);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(CompanyCreationDTO companyCreacion)
        {
            var company = await _companyService.CreateCompany(companyCreacion);

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var success = await _companyService.DeleteCompany(id);

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
