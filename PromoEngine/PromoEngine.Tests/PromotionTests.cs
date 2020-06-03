using NUnit.Framework;
using PromoEngine.App;
using PromoEngine.App.Models;
using System.Collections.Generic;

namespace PromoEngine.Tests
{
    public class Tests
    {
        PromotionEngine promotionEngine;
        List<OrderDetail> productCart;
        List<PromoDefinition> activePromotions;

        [SetUp]
        public void Setup()
        {
            promotionEngine = new PromotionEngine();

            this.productCart = new List<OrderDetail>()
            {
                new OrderDetail {Product = 'A', OriginalUnitPrice = 50 },
                new OrderDetail {Product = 'B', OriginalUnitPrice = 30 },
                new OrderDetail {Product = 'C', OriginalUnitPrice = 20 },
                new OrderDetail {Product = 'D', OriginalUnitPrice = 15 },
            };

            activePromotions = new List<PromoDefinition>()
            {
                new PromoDefinition { PromoType = PromotionTypes.SingleSku, ProductList = new[] { 'A'}, Quantity = 3, Value = 130 },
                new PromoDefinition { PromoType = PromotionTypes.SingleSku, ProductList = new[] { 'B'}, Quantity = 2, Value = 45 },
                new PromoDefinition { PromoType = PromotionTypes.DualProducts, ProductList = new[] { 'C', 'D' }, Quantity = 1, Value = 30 },
            };
        }

        [Test]
        public void TestScenarioA_NoPromotions_Applied()
        {
            SetProductQuantity('A', 1);
            SetProductQuantity('B', 1);
            SetProductQuantity('C', 1);

            promotionEngine.ApplyPromotions(activePromotions, productCart);

            Assert.False(promotionEngine.IsPromoApplied);
            Assert.AreEqual(0, promotionEngine.DiscountedAmount);
        }

        [Test]
        public void TestScenarioB_SingleSku_Applied()
        {
            SetProductQuantity('A', 5);
            SetProductQuantity('B', 5);
            SetProductQuantity('C', 1);

            promotionEngine.ApplyPromotions(activePromotions, productCart);

            double originalTotal = 420;
            double discountedTotal = 370;
            double expectedDiscount = originalTotal - discountedTotal;

            Assert.True(promotionEngine.IsPromoApplied);
            Assert.AreEqual(expectedDiscount, promotionEngine.DiscountedAmount);
        }

        private void SetProductQuantity(char product, int quantity)
        {
            foreach(var item in this.productCart)
            {
                if(item.Product == product)
                {
                    item.Quantity = quantity;
                    return;
                }
            }
        }
    }
}