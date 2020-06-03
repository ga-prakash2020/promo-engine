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
            foreach (var promo in activePromotions)
            {
                IPromotion promotion = PromotionFactory.GetFactory(promo);
                // no need to apply further promotions if a promotion is already applied
                if (!this.IsPromoApplied)
                {
                    this.DiscountedAmount = promotion.ApplyPromotion(productCart);
                    // mark promotion applied
                    if (this.DiscountedAmount > 0)
                    {
                        this.IsPromoApplied = true;
                    }
                }
            }
        }
    }
}
