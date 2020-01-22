using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    public class ShopItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public Image Image { get; set; }
        public int? ImageID { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

    }
}
