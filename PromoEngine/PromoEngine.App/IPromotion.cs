using PromoEngine.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoEngine.App
{
    public interface IPromotion
    {
        double OriginalPrice { get; }
        double PriceAfterDiscount { get; }
        double ApplyPromotion(List<OrderDetail> orderDetails);
    }
}
