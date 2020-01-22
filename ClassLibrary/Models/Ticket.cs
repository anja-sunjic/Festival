using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public TicketType Type { get; set; }
        public int? TicketTypeID { get; set; }
        public TicketVoucher TicketVoucher { get; set; }
        public int? TicketVoucherID { get; set; }
        public Attendee Attendee { get; set; }
        public int? AttendeeID { get; set; }
    }
}

