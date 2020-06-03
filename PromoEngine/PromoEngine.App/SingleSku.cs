using PromoEngine.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoEngine.App
{
    public class SingleSku : IPromotion
    {
        private readonly char product;
        private readonly int quantity;
        private readonly double promoPrice;

        public double OriginalPrice { get; private set; }
        public double PriceAfterDiscount { get; private set; }

        public SingleSku(PromoDefinition promo)
        {
            this.product = promo.ProductList[0];
            this.quantity = promo.Quantity;
            this.promoPrice = Convert.ToDouble(promo.Value);
        }

        public double ApplyPromotion(List<OrderDetail> orderDetails)
        {
            throw new NotImplementedException();
        }
    }
}
