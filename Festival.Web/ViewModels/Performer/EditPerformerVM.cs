using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FestivalWebApplication.ViewModels.Performer
{
    public class EditPerformerVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Performer name is required, please insert it.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fee is required, please insert the amount.")]
        [Range(1, float.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public float Fee { get; set; }
        [Required(ErrorMessage = "Promo text for the performer is required.")]
        public string PromoText { get; set; }
        public IFormFile Image { get; set; }
        public int ManagerId { get; set; }
        [Required(ErrorMessage = "Manager name is required, please insert it.")]
        public string ManagerName { get; set; }
        [Required(ErrorMessage = "Manager phone number is required, please insert it.")]
        public string ManagerPhoneNumber { get; set; }
        [Required(ErrorMessage = "Manager E-mail is required, please insert it.")]
        public string ManagerEmail { get; set; }
    }
}
