using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Festival.Web.ViewModels.Accommodation
{
    public class NewAccommodationVM
    {
        [Required(ErrorMessage = "Accommodation name is required, please insert it.")]
        [StringLength(25, ErrorMessage = "Name length can't be more than 25 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Accommodation phone number is required, please insert it.")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Accommodation distance to festival area is required, please insert it.")]
        [Range(0, 100.00, ErrorMessage = "Distance to festival area must be between 0 and 100 km")]
        public float Distance { get; set; }
        [Required(ErrorMessage = "Accommodation description is required, please insert it.")]
        [StringLength(100, ErrorMessage = "Description length can't be more than 100 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Accommodation address is required, please insert it.")]
        [StringLength(25, ErrorMessage = "Address length can't be more than 25 characters.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Accommodation picture is required, please insert it.")]
        public IFormFile ProfileImage { get; set; }
    }
}
