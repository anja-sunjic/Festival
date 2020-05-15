using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Festival.Web.Areas.Admin.ViewModels.TransferReservation
{
    public class NewTransferReservationVM
    {
        public List<SelectListItem> Attendees { get; set; }
        public int AttendeeID { get; set; }
        public List<SelectListItem> TransferServices { get; set; }
        public int TransferServiceID { get; set; }

    }
}
