using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

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
