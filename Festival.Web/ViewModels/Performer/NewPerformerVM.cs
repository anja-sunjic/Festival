using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Festival.Web.ViewModels.Performer
{
    public class NewPerformerVM
    {
        [Required(ErrorMessage = "Performer name is required, please insert it.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fee is required, please insert the amount.")]
        [Range(1, float.MaxValue, ErrorMessage = "Value should be greater than 1")]
        public float Fee { get; set; }
        [Required(ErrorMessage = "Promo text for the performer is required.")]
        public string PromoText { get; set; }
        [Required(ErrorMessage = "Picture is required, please pick one.")]
        public IFormFile Image { get; set; }

        public string ManagerName { get; set; }

        public string ManagerPhoneNumber { get; set; }

        public string ManagerEmail { get; set; }
        public List<SelectListItem> Managers { get; set; }
        public int? ManagerId { get; set; }
    }
}
