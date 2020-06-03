using System;
using System.Collections.Generic;
using System.Text;

namespace PromoEngine.App.Models
{
    public class PromoDefinition
    {
        public PromotionTypes PromoType { get; set; }
        public char[] ProductList { get; set; }
        public int Quantity { get; set; }
        public object Value { get; set; }
    }
}
