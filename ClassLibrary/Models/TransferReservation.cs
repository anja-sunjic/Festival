namespace Festival.Data.Models
{
    public class TransferReservation
    {
        public int ID { get; set; }
        public Attendee Attendee { get; set; }
        public int? AttendeeID { get; set; }
        public TransferService TransferService { get; set; }
        public int? TransferServiceID { get; set; }

    }
}
