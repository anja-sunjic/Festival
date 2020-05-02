using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CustomDataAnnotations;

namespace FestivalWebApplication.ViewModels.Performance
{
    public class DetailPerformanceVM
    {
        public int ID { get; set; }
        public DateTime Start { get; set; }
        public string StageName { get; set; }
        public string PerformerName { get; set; }
        public string PerformerPicture { get; set; }
    }
}
