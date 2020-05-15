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

        public List<PurchaseVoucher> GetAll()
        {
            return context.PurchaseVoucher.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
