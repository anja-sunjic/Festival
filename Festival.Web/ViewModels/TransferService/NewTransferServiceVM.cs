using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalWebApplication.ViewModels.TransferService
{
    public class NewTransferServiceVM
    {
        public int Id { get; set; }
        public List<SelectListItem> Vehicles{ get; set; }
        public int VehicleId { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime Date { get; set; }
    }
}
