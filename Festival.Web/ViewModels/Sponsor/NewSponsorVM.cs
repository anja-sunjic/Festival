using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Festival.Web.ViewModels.Sponsor
{
    public class NewSponsorVM
    {
        [Required(ErrorMessage = "Company name is required, please insert it.")]
        [StringLength(25, ErrorMessage = "Comapny name length can't be more than 25 characters.")]
        [DisplayName("Company name")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Sponsor picture is required, please insert it.")]
        public IFormFile Image { get; set; }
        [DisplayName("Contact person name")]
        [Required(ErrorMessage = "Contact person name is required, please insert it.")]
        [StringLength(25, ErrorMessage = "Contact person name length can't be more than 25 characters.")]
        public string ContactPersonName { get; set; }
        [Required(ErrorMessage = "Accommodation phone number is required, please insert it.")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required, please insert it.")]
        [StringLength(50, ErrorMessage = "Address length can't be more than 50 characters.")]
        public string Address { get; set; }
    }
}
