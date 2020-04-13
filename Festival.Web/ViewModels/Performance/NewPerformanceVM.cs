using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalWebApplication.ViewModels.Performance
{
    public class NewPerformanceVM
    {
        public DateTime Start { get; set; }
        public List<SelectListItem> Stages { get; set; }
        public int? StageID { get; set; }
        public List<SelectListItem> Performers { get; set; }
        public int? PerformerID { get; set; }
    
}
}
