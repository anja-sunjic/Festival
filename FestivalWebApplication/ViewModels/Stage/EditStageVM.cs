using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FestivalWebApplication.ViewModels.Stage
{
    public class EditStageVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<SelectListItem> Sponsors { get; set; }
        public int SponsorId { get; set; }
        public string SponsorName { get; set; }
    }
}
