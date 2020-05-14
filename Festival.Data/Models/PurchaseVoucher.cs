using System.Collections.Generic;

namespace Festival.Data.Models
{
    public class PurchaseVoucher : Voucher
    {
        public List<Purchase> RedeemedPurchasesWithVouchers { get; set; }

    }
}
