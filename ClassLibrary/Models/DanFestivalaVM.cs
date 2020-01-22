using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    class DanFestivalaVM
    {
        public int ID { get; set; }
        public DateTime date { get; set; }
        public IEnumerable<Performance> performances { get; set; }
    }
}
