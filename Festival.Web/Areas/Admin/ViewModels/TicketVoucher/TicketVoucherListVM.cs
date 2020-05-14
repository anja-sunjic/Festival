using System;

namespace Festival.Web.Areas.Admin.ViewModels.TicketVoucher
{
    public class TicketVoucherListVM
    {
        public int ID { get; set; }
        public string VoucherCode { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Discount { get; set; }
        public int NumberOfRedeemedVouchers { get; set; }
    }
}
