﻿using System;
namespace Festival.Data.Models
{
    public abstract class Voucher
    {
        public int ID { get; set; }
        public string VoucherCode { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Discount { get; set; }
        public int NumberOfRedeemedVouchers { get; set; }
    }
}
