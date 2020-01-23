using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FestivalWebApplication.ViewModels.Stage
{
    public class NewStageVM
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<SelectListItem> Sponsors { get; set; }
        public int? SponsorID { get; set; }
    }
}
