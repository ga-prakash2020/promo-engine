using System;
using System.Collections.Generic;
using System.Text;

namespace PromoEngine.App.Models
{
    public class OrderDetail
    {
        public char Product { get; set; }
        public int Quantity { get; set; }
        public double OriginalUnitPrice { get; set; }
    }
}
