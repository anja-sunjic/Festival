using Festival.Data.Models;
using System.Collections.Generic;

namespace Festival.Data.Repositories
{
    public interface IPurchaseVoucherRepository
    {
        List<PurchaseVoucher> GetAll();
        void Add(PurchaseVoucher voucher);
        void Save();
        PurchaseVoucher GetByID(int iD);
    }
}
