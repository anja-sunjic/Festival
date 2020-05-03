﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FestivalWebApplication.ViewModels.Stage
{
    public class NewStageVM
    {
        [Required(ErrorMessage = "Stage name is required, please insert it.")]
        [DisplayName("Stage name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Capacity is required, please insert the amount.")]
        [Range(1, float.MaxValue, ErrorMessage = "Value should be greater than 1")]
        public int Capacity { get; set; }
        public List<SelectListItem> Sponsors { get; set; }
        public int? SponsorID { get; set; }
    }
}
