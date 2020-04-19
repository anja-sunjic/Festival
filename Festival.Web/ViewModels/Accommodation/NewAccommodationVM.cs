using Microsoft.AspNetCore.Http;

namespace FestivalWebApplication.ViewModels.Accommodation
{
    public class NewAccommodationVM
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public float Distance { get; set; }
        public string Description { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
