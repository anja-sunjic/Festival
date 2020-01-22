using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    public enum VoucherType { purchase, ticket}
    
    public abstract class Voucher
    {
        public int ID { get; set; }
        public DateTime SaleDate { get; set; }
        public VoucherType Type { get; set; }
        public int? VoucherTypeID { get; set; }

    }
}
