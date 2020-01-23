using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Http;

namespace FestivalWebApplication.ViewModels.Performer
{
    public class EditPerformerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Fee { get; set; }
        public string PromoText { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string ManagerPhoneNumber { get; set; }
        public string ManagerEmail { get; set; }
    }
}
