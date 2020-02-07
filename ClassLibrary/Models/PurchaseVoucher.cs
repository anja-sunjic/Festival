using System.ComponentModel.DataAnnotations.Schema;

namespace Festival.Data.Models
{
    public class PurchaseVoucher : Voucher
    {
        [ForeignKey("PurchaseID")]
        public Purchase Purchase { get; set; }
        public int? PurchaseID { get; set; }

    }
}
