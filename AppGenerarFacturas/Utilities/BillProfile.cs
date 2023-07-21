using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AppGenerarFacturas.Utilities
{
    public class BillProfile : Profile
    {
        
        public BillProfile()
        {
            
            //// Mapeo de Factura a BillDTO
            CreateMap<Bill,BillDTO>();
            

            //// Mapeo de BillDTO a Bill
            CreateMap<BillDTO, Bill>();
            

            //// Mapeo de LineaFactura a InvoiseLineDTO
            CreateMap<InvoiseLine, InvoiseLineDTO>();
            CreateMap<InvoiseLineDTO, InvoiseLine>();
            

            //// Mapeo de Empresa a CompanyDTO
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();
            

            
        }
    }
}
