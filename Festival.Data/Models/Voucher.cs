using Festival.Data.Enumerations;
using System;
namespace Festival.Data.Models
{
    public abstract class Voucher
    {
        public int ID { get; set; }
        public DateTime SaleDate { get; set; }
        public VoucherType Type { get; set; }
        public int? VoucherTypeID { get; set; }

    }
}
