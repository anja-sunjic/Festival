using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Festival.Data.Models
{
    public class TransferService
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Date of transfer service is required, please insert it.")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Number of available seats left is required, please insert it.")]
        [Range(1, 30, ErrorMessage = "Number of available seats must be between 1 and 30 persons.")]
        [DisplayName("Number of available seats")]
        public int NumberOfAvailableSeats { get; set; }
        [Required(ErrorMessage = "Meeting point is required, please insert it.")]
        [StringLength(25, ErrorMessage = "Meeting point length can't be more than 25 characters.")]
        [DisplayName("Meeting point")]
        public string MeetingPoint { get; set; }
        [DisplayName("Transfer vehicle")]
        public TransferVehicle TransferVehicle { get; set; }
        [Required(ErrorMessage = "Transfer vehicle for service is required, please insert it.")]
        public int TransferVehicleID { get; set; }
    }
}
