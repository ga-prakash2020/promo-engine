using PromoEngine.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var detail = orderDetails.Where(x => x.Product == this.product).FirstOrDefault();

            if (detail == null) return 0;

            var originalPrice = detail.Quantity * detail.OriginalUnitPrice;
            this.OriginalPrice = originalPrice;

            if (detail.Quantity >= this.quantity)
            {
                var times = detail.Quantity / this.quantity;
                var rem = detail.Quantity % this.quantity;

                var priceAfterDiscount = (this.promoPrice * times) + (rem * detail.OriginalUnitPrice);
                this.PriceAfterDiscount = priceAfterDiscount;

                return originalPrice - priceAfterDiscount;
            }
            this.PriceAfterDiscount = this.OriginalPrice;
            return 0;
        }
    }
}
