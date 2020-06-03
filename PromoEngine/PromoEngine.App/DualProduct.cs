using PromoEngine.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var prod1Detail = orderDetails.Where(x => x.Product == product1).FirstOrDefault();
            var prod2Detail = orderDetails.Where(x => x.Product == product2).FirstOrDefault();

            if (prod1Detail == null || prod2Detail == null) return 0;

            var originalPrice = (prod1Detail.Quantity * prod1Detail.OriginalUnitPrice) +
                (prod2Detail.Quantity * prod2Detail.OriginalUnitPrice);

            this.OriginalPrice = originalPrice;

            var count = Math.Min(prod1Detail.Quantity, prod2Detail.Quantity);

            var priceAfterDiscount = (count * this.promoPrice) + ((prod1Detail.Quantity - count) * prod1Detail.OriginalUnitPrice)
                + ((prod2Detail.Quantity - count) * prod2Detail.OriginalUnitPrice);

            this.PriceAfterDiscount = priceAfterDiscount;

            var discount = originalPrice - priceAfterDiscount;

            if (discount == 0) this.PriceAfterDiscount = this.OriginalPrice;

            return discount;
        }
    }
}
