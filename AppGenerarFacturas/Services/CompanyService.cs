using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AppGenerarFacturas.Services.contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppGenerarFacturas.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public CompanyService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<Company>>> getCompanies()
        {
            var companies = await _context.Companies.ToListAsync();

            if(companies == null)
            {
                return new NotFoundObjectResult(null);
            }

            return companies;
        }

        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            if (_context.Companies == null)
            {
                return new NotFoundObjectResult(null);
            }
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return new NotFoundObjectResult(null);
            }

            return company;
        }

        public async Task<IActionResult> UpdateCompany(int id, Company updatedCompany)
        {
            if(id != updatedCompany.Id)
            {
                return new BadRequestResult();
            }

            _context.Entry(updatedCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        public async Task<Company> CreateCompany(CompanyCreationDTO companyCreacion)
        {
            if (_context.Companies == null)
            {
                throw new Exception("Entity set 'ApplicationDBContext.Users' is null.");
            }

            var company = _mapper.Map<Company>(companyCreacion);
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return company;
        }

        public async Task<bool> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if(company == null)
            {
                return false;
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool CompanyExists(int id)
        {
            return (_context.Companies?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
