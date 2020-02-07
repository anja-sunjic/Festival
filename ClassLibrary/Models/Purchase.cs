using System.Collections.Generic;

namespace Festival.Data.Models
{
    public class Purchase
    {
        public int ID { get; set; }
        public List<ShopItem> Items { get; set; }
        public PurchaseVoucher PurchaseVoucher { get; set; }
        public int? PurchaseVoucherID { get; set; }
        public Attendee Attendee { get; set; }
        public int? AttendeeID { get; set; }
    }
}
