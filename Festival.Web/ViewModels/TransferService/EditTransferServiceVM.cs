using Festival.Web.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Festival.Web.ViewModels.TransferService
{
    public class EditTransferServiceVM
    {
        public int Id { get; set; }
        public List<SelectListItem> Vehicles { get; set; }
        public int VehicleId { get; set; }
        [Required(ErrorMessage = "Meeting point is required, please insert it.")]
        [StringLength(25, ErrorMessage = "Meeting point length can't be more than 25 characters.")]
        [DisplayName("Meeting point")]
        public string MeetingPoint { get; set; }
        [Required(ErrorMessage = "Number of available seats left is required, please insert it.")]
        [Range(1, 30, ErrorMessage = "Number of available seats must be between 1 and 30 persons.")]
        [DisplayName("Number of available seats")]
        public int AvailableSeats { get; set; }
        [Required(ErrorMessage = "Date of transfer service is required, please insert it.")]
        [CurrentDate(ErrorMessage = "Date must be after or equal to current date")]
        public DateTime Date { get; set; }
    }
}
