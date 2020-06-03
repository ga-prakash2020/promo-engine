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
                    return new SingleSku();
                case PromotionTypes.DualProducts:
                    return new DualProduct();
                // case Percentage
                default:
                    return new SingleSku();
            }
        }
    }
}
