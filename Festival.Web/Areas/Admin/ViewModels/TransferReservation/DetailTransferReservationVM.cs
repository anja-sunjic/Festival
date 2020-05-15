using System;

namespace Festival.Web.Areas.Admin.ViewModels.TransferReservation
{
    public class DetailTransferReservationVM
    {
        public int ID { get; set; }
        public string AttendeeName { get; set; }
        public string AttendeeEmail { get; set; }
        public string VehicleName { get; set; }
        public DateTime DateOfService { get; set; }
        public string MeetingPoint { get; set; }
    }
}
