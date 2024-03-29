﻿using AppGenerarFacturas.DataAccess;
using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using AppGenerarFacturas.Services.contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Drawing;

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

        public async Task<IEnumerable<Bill>> getBills()
        {
            var bills = await _context.Bills.Include(b => b.Company).Include(b => b.InvoiseLines).ToListAsync();

            return bills;
        }

        public async Task<Bill> GetBill(int id)
        {
            
            var bill = await _context.Bills.Include(b => b.Company).Include(b => b.InvoiseLines).FirstOrDefaultAsync(b => b.Id == id);

            return bill;
        }

        public async Task UpdateBill(Bill bill)
        {
            var billItem = await _context.Bills.FirstOrDefaultAsync(x=> x.Id == bill.Id);

            if(billItem != null)
            {
                billItem.BillNumber = bill.BillNumber;
                billItem.Time = bill.Time;
                billItem.Total = bill.Total;
                billItem.InvoiseLines = bill.InvoiseLines;
                billItem.Company = bill.Company;

                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<Bill> CreateBill(Bill bill)
        {
            if (_context.Bills == null)
            {
                throw new Exception("Entity set 'ApplicationDBContext.Bills' is null.");
            }

            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();

            return bill;
        }

        public async Task DeleteBill(Bill bill)
        {
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
        }

        public async Task<Bill> UpdateBillInvoiseList(BillDTO billDTO)
        {
            // Mapear el DTO a una entidad
            var billEntity = _mapper.Map<Bill>(billDTO);

            // Si se realizarán cambios en las líneas de factura, debes asegurarte de manejarlos adecuadamente
            // Por ejemplo, aquí asumiremos que las líneas de factura se mantendrán sin cambios y solo se actualizarán otros campos de la factura

            // Actualizar la factura en la base de datos
            _context.Bills.Update(billEntity);
            await _context.SaveChangesAsync();
            return billEntity;
        }

        public async Task<Bill> GetBillById(int billId)
        {
            return await _context.Bills.FindAsync(billId);
        }
        






        private bool BillExists(int id)
        {
            return (_context.Bills?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }


}
