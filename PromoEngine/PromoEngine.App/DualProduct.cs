using PromoEngine.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoEngine.App
{
    public class DualProduct : IPromotion
    {
        public double OriginalPrice => throw new NotImplementedException();

        public double PriceAfterDiscount => throw new NotImplementedException();

        public double ApplyPromotion(List<OrderDetail> orderDetails)
        {
            throw new NotImplementedException();
        }
    }
}
