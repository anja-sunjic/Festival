using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festival.Web.Areas.Guest.ViewModels.Performer
{
    public class PerformerDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PromoText { get; set; }
        public string Picture { get; set; }
    }
}
