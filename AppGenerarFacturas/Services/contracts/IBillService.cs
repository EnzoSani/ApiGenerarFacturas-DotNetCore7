﻿using AppGenerarFacturas.DTOS;
using AppGenerarFacturas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppGenerarFacturas.Services.contracts
{
    public interface IBillService
    {
        Task<Bill> CreateBill(Bill bill);
        Task DeleteBill(Bill bill);
        Task<Bill> GetBill(int id);
        Task<Bill> GetBillById(int billId);
        Task<IEnumerable<Bill>> getBills();
        Task UpdateBill(Bill bill);
        Task<Bill> UpdateBillInvoiseList(BillDTO billDTO);
    }
}
