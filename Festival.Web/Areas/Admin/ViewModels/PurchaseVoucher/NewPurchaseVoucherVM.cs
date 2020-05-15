using System;

namespace Festival.Web.Areas.Admin.ViewModels.PurchaseVoucher
{
    public class NewPurchaseVoucherVM
    {
        public string VoucherCode { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Discount { get; set; }
    }
}
