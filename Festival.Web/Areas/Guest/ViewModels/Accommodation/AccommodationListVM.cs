using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festival.Web.Areas.Guest.ViewModels.Accommodation
{
        public class AccommodationListVM
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public float Distance { get; set; }
            public string Description { get; set; }
            public string Address { get; set; }
            public string Picture { get; set; }
        }
    
}
