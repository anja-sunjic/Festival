using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalWebApplication.ViewModels.Performance
{
    public class PerformanceListVM
    {
        public int PerformanceID { get; set; }
        public string Start { get; set; }
        public string Performer { get; set; }
        public string Stage { get; set; }
    }
}
