using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary.Models
{
    public class PurchaseVoucher:Voucher
    {
        [ForeignKey("PurchaseID")]
        public Purchase Purchase { get; set; }
        public int? PurchaseID { get; set; }

    }
}
