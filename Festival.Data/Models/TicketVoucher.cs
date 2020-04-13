using System.ComponentModel.DataAnnotations.Schema;
namespace Festival.Data.Models
{
    public class TicketVoucher : Voucher
    {
        [ForeignKey("TicketID")]
        public Ticket Ticket { get; set; }
        public int? TicketID { get; set; }


    }
}
