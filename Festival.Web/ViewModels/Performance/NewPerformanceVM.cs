using Festival.Web.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Festival.Web.ViewModels.Performance
{
    public class NewPerformanceVM
    {

        [Required(ErrorMessage = "Start date and time of performance is required, please insert one.")]
        [CurrentDate(ErrorMessage = "Date must be greater than current date.")]
        public DateTime Start { get; set; }
        public List<SelectListItem> Stages { get; set; }
        public int? StageID { get; set; }
        public List<SelectListItem> Performers { get; set; }
        public int? PerformerID { get; set; }
    }
}
