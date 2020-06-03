using NUnit.Framework;
using PromoEngine.App;
using PromoEngine.App.Models;
using System.Collections.Generic;

namespace PromoEngine.Tests
{
    public class Tests
    {
        PromotionEngine promotionEngine;

        [SetUp]
        public void Setup()
        {
            promotionEngine = new PromotionEngine();
        }

        [Test]
        public void NoPromotionApplied()
        {
            var productCart = new List<OrderDetail>()
            {
                new OrderDetail {Product = 'A', OriginalUnitPrice = 50, Quantity = 1 },
                new OrderDetail {Product = 'B', OriginalUnitPrice = 30, Quantity = 1 },
                new OrderDetail {Product = 'C', OriginalUnitPrice = 20, Quantity = 1 },
                //new OrderDetail {Product = 'D', OriginalUnitPrice = 15, Quantity = 1 },
            };

            var activePromotions = new List<PromoDefinition>()
            {
                new PromoDefinition { PromoType = PromotionTypes.SingleSku, ProductList = new[] { 'A'}, Quantity = 3, Value = 130 },
                new PromoDefinition { PromoType = PromotionTypes.SingleSku, ProductList = new[] { 'B'}, Quantity = 2, Value = 45 },
                new PromoDefinition { PromoType = PromotionTypes.DualProducts, ProductList = new[] { 'C', 'D' }, Quantity = 1, Value = 30 },
            };

            promotionEngine.ApplyPromotions(activePromotions, productCart);

            Assert.False(promotionEngine.IsPromoApplied);
            Assert.AreEqual(0, promotionEngine.DiscountedAmount);
        }
}