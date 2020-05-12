using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festival.Web.Areas.Guest.ViewModels.Stage
{
    public class StageDetailsVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string SponsorName { get; set; }
        public string SponsorImage { get; set; }        
        public string Image { get; set; }
    }
}
