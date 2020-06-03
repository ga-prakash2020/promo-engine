using PromoEngine.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoEngine.App
{
    public class PromotionFactory
    {
        public static IPromotion GetFactory(PromoDefinition promoDef)
        {
            switch (promoDef.PromoType)
            {
                case PromotionTypes.SingleSku:
                    return new SingleSku(promoDef);
                case PromotionTypes.DualProducts:
                    return new DualProduct(promoDef);
                // case Percentage
            }

            throw new ArgumentException("Unable to create PromotionType, invalid promotion type");
        }
    }
}
