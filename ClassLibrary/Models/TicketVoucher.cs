using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary.Models
{
    public class TicketVoucher: Voucher
    {
        [ForeignKey("TicketID")]
        public Ticket Ticket { get; set; }
        public int? TicketID { get; set; }
       

    }
}
