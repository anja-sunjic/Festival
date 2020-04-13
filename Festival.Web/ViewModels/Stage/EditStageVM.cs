using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

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
