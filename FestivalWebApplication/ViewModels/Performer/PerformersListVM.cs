using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalWebApplication.ViewModels.Performer
{
    public class PerformersListVM
    {
        public int PerformerID { get; set; }
        public int Number { get; set; }
        public string PerformerName { get; set; }
        public string ManagerName { get; set; }
    }
}
