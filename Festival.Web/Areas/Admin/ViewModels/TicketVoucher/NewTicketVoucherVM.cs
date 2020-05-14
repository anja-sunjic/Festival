using System;

namespace Festival.Web.Areas.Admin.ViewModels.TicketVoucher
{
    public class NewTicketVoucherVM
    {
        public string VoucherCode { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Discount { get; set; }
    }
}
