using System.ComponentModel.DataAnnotations;

namespace Festival.Web.ViewModels.TicketType
{
    public class NewTicketTypeVM
    {
        [Required(ErrorMessage = "Name is required, please insert it.")]
        [StringLength(25, ErrorMessage = "Name length can't be more than 25 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required, please insert it.")]
        [Range(0, 1000, ErrorMessage = "Price must be between 0 and 1000 KM")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Description is required, please insert it.")]
        [StringLength(50, ErrorMessage = "Description length can't be more than 50 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Tier is required, please insert it.")]
        public int Tier { get; set; }
    }
}
