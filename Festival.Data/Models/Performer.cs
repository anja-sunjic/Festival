using System.ComponentModel.DataAnnotations;

namespace Festival.Data.Models
{
    public class Performer
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required, please insert it.")]
        [StringLength(25, ErrorMessage = "Name length can't be more than 25 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fee is required, please insert the amount.")]
        [Range(1, float.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public float Fee { get; set; }
        [Required(ErrorMessage = "Promo text for the performer is required.")]
        public string PromoText { get; set; }
        [Required(ErrorMessage = "Picture is required, please insert it.")]
        public string Picture { get; set; }
        public Manager Manager { get; set; }
        public int? ManagerID { get; set; }
    }
}
