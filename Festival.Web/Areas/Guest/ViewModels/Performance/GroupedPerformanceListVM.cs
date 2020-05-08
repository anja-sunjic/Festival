using System.Collections.Generic;

namespace Festival.Web.Areas.Guest.ViewModels.Performance
{
    public class GroupedPerformanceListVM
    {
        public string Key { get; set; }
        public List<PerformanceListVM> Performances { get; set; }

    }
}
