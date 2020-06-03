using PromoEngine.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoEngine.App
{
    public class PromotionEngine
    {
        public bool IsPromoApplied { get; set; } = false;
        public double DiscountedAmount { get; set; } = 0;

        public void ApplyPromotions(List<PromoDefinition> activePromotions, List<OrderDetail> productCart)
        {

        }
    }
}
