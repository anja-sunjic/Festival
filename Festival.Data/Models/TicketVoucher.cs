using System.Collections.Generic;

namespace Festival.Data.Models
{
    public class TicketVoucher : Voucher
    {
        public List<Ticket> RedeemedTicketsWithVouchers { get; set; }
    }
}
