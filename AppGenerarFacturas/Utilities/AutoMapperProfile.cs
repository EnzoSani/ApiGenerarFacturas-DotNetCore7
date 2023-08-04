using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AppGenerarFacturas.Utilities
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            // Mapeo de Factura a BillDTO
            CreateMap<Bill, BillDTO>();
            CreateMap<BillDTO, Bill>();

            // Mapeo de LineaFactura a InvoiseLineDTO
            CreateMap<InvoiseLine, InvoiseLineDTO>();
            CreateMap<InvoiseLineDTO, InvoiseLine>();

            // Mapeo de Empresa a CompanyDTO
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();
        }
    }
}
