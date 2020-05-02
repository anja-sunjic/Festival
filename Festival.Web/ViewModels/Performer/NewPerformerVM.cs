using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FestivalWebApplication.ViewModels.Performer
{
    public class NewPerformerVM
    {
        [Required(ErrorMessage = "Performer name is required, please insert it.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fee is required, please insert the amount.")]
        [Range(1, 5000, ErrorMessage = "Value should be between 1 and 5000 KM.")]
        public float Fee { get; set; }
        [Required(ErrorMessage = "Promo text for the performer is required.")]
        public string PromoText { get; set; }
        [Required(ErrorMessage = "Picture is required, please pick one.")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "Manager name is required, please insert it.")]
        public string ManagerName { get; set; }
        [Required(ErrorMessage = "Manager phone number is required, please insert it.")]
        public string ManagerPhoneNumber { get; set; }
        [Required(ErrorMessage = "Manager E-mail is required, please insert it.")]
        public string ManagerEmail { get; set; }
    }
}
