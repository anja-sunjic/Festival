using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Festival.Web.ViewModels.ShopItem
{
    public class NewShopItemVM
    {
        [Required(ErrorMessage = "Name is required, please insert it.")]
        [StringLength(25, ErrorMessage = "Name length can't be more than 25 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required, please insert it.")]
        [Range(1, 10000, ErrorMessage = "Price must be between 1KM and 10000 KM.")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Quantity is required, please insert it.")]
        [Range(1, 1000, ErrorMessage = "Quantity of items in stock must be between 1 and 1000.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Description is required, please insert it.")]
        [StringLength(100, ErrorMessage = "Description length can't be more than 100 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Picture is required, please insert it.")]
        public IFormFile ProfileImage { get; set; }
    }
}
