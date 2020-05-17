using System;
using Festival.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Data.Repositories
{
    public class PurchaseVoucherRepository : IPurchaseVoucherRepository
    {
        private readonly FestivalContext context;

        public PurchaseVoucherRepository(FestivalContext context)
        {
            this.context = context;
        }

        public void Add(PurchaseVoucher voucher)
        {
            context.PurchaseVoucher.Add(voucher);
            Save();
        }

        public void Delete(int iD)
        {
            var voucher = context.PurchaseVoucher.Find(iD);
            if(voucher == null) throw new Exception($"Can't find purchase voucher with Id: {iD}");

            context.PurchaseVoucher.Remove(voucher);
            Save();
        }

        public List<PurchaseVoucher> GetAll()
        {
            return context.PurchaseVoucher.ToList();
        }

        public PurchaseVoucher GetByID(int iD)
        {
            var voucher = context.PurchaseVoucher.Find(iD);
            if (voucher == null) throw new Exception($"Can't find purchase voucher with Id: {iD}");

            return voucher;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
