using Microsoft.AspNetCore.Http;

namespace FestivalWebApplication.ViewModels.Sponsor
{
    public class EditSponsorVM
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactPersonName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }

    }
}
