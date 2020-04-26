using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Festival.Data.Models
{
    public class TransferVehicle
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required, please insert it.")]
        [StringLength(25, ErrorMessage = "Name length can't be more than 25 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Registration number is required, please insert it.")]
        [StringLength(15, ErrorMessage = "Registration number length can't be more than 15 characters.")]
        [DisplayName("Registration number")]
        public string RegistrationNumber { get; set; }
        [Required(ErrorMessage = "Driver is required, please insert it.")]
        [StringLength(30, ErrorMessage = "Driver name length can't be more than 30 characters.")]
        public string Driver { get; set; }
        [Required(ErrorMessage = "Capacity of vehicle is required, please insert it.")]
        [Range(1, 100, ErrorMessage = "Capacity must be between 1 and 30 persons.")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Picture is required, please insert it.")]
        public string Picture { get; set; }
    }
}
