using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    public class Stage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Sponsor Sponsor { get; set; }
        public int? SponsorID { get; set; }
    }
}

