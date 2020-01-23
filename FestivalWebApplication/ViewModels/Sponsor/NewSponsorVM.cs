using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Http;

namespace FestivalWebApplication.ViewModels.Sponsor
{ 
    public class NewSponsorVM
    {
        public string CompanyName { get; set; }
        public IFormFile Image { get; set; }
        public string ContactPersonName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
