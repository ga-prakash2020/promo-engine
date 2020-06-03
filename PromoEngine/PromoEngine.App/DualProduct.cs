using PromoEngine.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoEngine.App
{
    public class DualProduct : IPromotion
    {
        private readonly char product1;
        private readonly char product2;
        private readonly double promoPrice;

        public double OriginalPrice { get; private set; }
        public double PriceAfterDiscount { get; private set; }

        public DualProduct(PromoDefinition promo)
        {
            this.product1 = promo.ProductList[0];
            this.product2 = promo.ProductList[1];
            this.promoPrice = Convert.ToDouble(promo.Value);
        }

        public double ApplyPromotion(List<OrderDetail> orderDetails)
        {
            throw new NotImplementedException();
        }
    }
}
