using NUnit.Framework;
using Supermarket;

namespace SupermarketTest
{
    [TestFixture]
    public class UnitTest
    {
        // by units
        [TestCase(10, 25)]
        // by weight
        [TestCase(10.5, 26.25)]
        public void GenericItemTest(double qty, double expected)
        {
            GenericItem item = new GenericItem("Generic Item Name", 2.50);
            Assert.AreEqual(expected, item.GetPrice(qty));
        }

        // by units
        [TestCase(2, 1, 10, 10.5)]
        // by weight
        [TestCase(1.5, 2.5, 10, 7.5)]
        public void BuyXGetYFreeItemTest(double buyX, double buyY, double qty, double expected)
        {
            BuyXGetYFreeItem item = new BuyXGetYFreeItem("Buy X Get Y Free Item Name", 1.50, buyX, buyY);
            Assert.AreEqual(expected, item.GetPrice(qty));
        }

        // by units
        [TestCase(2, 2.5, 10, 12.5)]
        // by weight
        [TestCase(2.5, 3, 10, 12)]
        public void BuyXatYPriceItemTest(double buyX, double priceY, double qty, double expected)
        {
            BuyXatYPriceItem item = new BuyXatYPriceItem("Buy X at Y Price Item Name", 1.50, buyX, priceY);
            Assert.AreEqual(expected, item.GetPrice(qty));
        }

        [Test]
        public void NewCartTest()
        {
            GenericItem item = new GenericItem("Generic Item Name 1", 2.50);

            ShoppingCart.AddToCart(item, 2);
            ShoppingCart.NewCart();

            Assert.AreEqual(0, ShoppingCart.GetNumUniqueItems());
        }

        [Test]
        public void CartNumUniqueItemTest()
        {
            GenericItem item1 = new GenericItem("Generic Item Name 1", 2.50);
            GenericItem item2 = new GenericItem("Generic Item Name 2", 1);

            ShoppingCart.NewCart();
            ShoppingCart.AddToCart(item1, 2);
            ShoppingCart.AddToCart(item2, 3);
            ShoppingCart.AddToCart(item1, 5);

            Assert.AreEqual(2, ShoppingCart.GetNumUniqueItems());
        }

        [Test]
        public void CartTotalPriceTest()
        {
            ShoppingCart.NewCart();
            ShoppingCart.AddToCart(new GenericItem("a", 1.00), 10); // unit
            ShoppingCart.AddToCart(new GenericItem("b", 1.00), 10.5); // weight
            ShoppingCart.AddToCart(new BuyXGetYFreeItem("c", 1.00, 2, 1), 10); // unit
            ShoppingCart.AddToCart(new BuyXGetYFreeItem("d", 1.00, 1.5, 1), 10); // weight

            Assert.AreEqual(10 + 10.5 + 7 + 6, ShoppingCart.GetTotalPrice());
        }
    }
}
