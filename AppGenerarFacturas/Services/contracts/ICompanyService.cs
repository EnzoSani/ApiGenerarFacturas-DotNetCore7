using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppGenerarFacturas.Services.contracts
{
    public interface ICompanyService
    {
        Task<Company> CreateCompany(CompanyCreationDTO companyCreacion);
        Task<bool> DeleteCompany(int id);
        Task<ActionResult<IEnumerable<Company>>> getCompanies();
        Task<ActionResult<Company>> GetCompany(int id);
        Task<IActionResult> UpdateCompany(int id, Company updatedCompany);
    }
}
