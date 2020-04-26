using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CustomDataAnnotations;

namespace FestivalWebApplication.ViewModels.TransferService
{
    public class NewTransferServiceVM
    {
        public int Id { get; set; }
        public List<SelectListItem> Vehicles{ get; set; }
        public int VehicleId { get; set; }
        public int AvailableSeats { get; set; }
        [Required(ErrorMessage = "Start date and time of performance is required, please insert it.")]
        [CurrentDate(ErrorMessage = "Date must be after or equal to current date")]
        public DateTime Date { get; set; }
    }
}
