using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalWebApplication.ViewModels.Stage
{
    public class StagesListVM
    {
        public int StageID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Sponsor { get; set; }
    }
}
