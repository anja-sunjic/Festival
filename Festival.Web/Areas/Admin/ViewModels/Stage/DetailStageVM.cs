using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festival.Web.ViewModels.Stage
{
    public class DetailStageVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string SponsorName { get; set; }
        public string Image { get; set; }
    }
}
