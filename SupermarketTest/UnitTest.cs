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
        public void BuyXGetYFreeItemTest(double buyX, double getY, double qty, double expected)
        {
            BuyXGetYFreeItem item = new BuyXGetYFreeItem("Buy X Get Y Free Item Name", 1.50, buyX, getY);
            Assert.AreEqual(expected, item.GetPrice(qty));
        }

        // by units
        [TestCase(2, 2.5, 10, 12.5)]
        // by weight
        [TestCase(2.5, 3, 10, 12)]
        public void BuyXatYPriceItemTest(double buyX, double priceY, double qty, double expected)
        {
            BuyXatPriceYItem item = new BuyXatPriceYItem("Buy X at Price Y Item Name", 1.50, buyX, priceY);
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
            FillUpCart();

            double expected = 25 + 26.25 + 10.5 + 7.5 + 12.5 + 12; // prices from individual tests
            Assert.AreEqual(expected, ShoppingCart.GetTotalPrice());
        }

        [Test]
        public void ReceiptTest()
        {
            FillUpCart();

            string expected = "Name       Quantity     Price\r\n" +
                              "-----------------------------\r\n" +
                              "Item 1     10         $ 25.00\r\n" +
                              "Item 2     10.5kg     $ 26.25\r\n" +
                              "Item 3     10         $ 10.50\r\n" +
                              "Item 4     10kg       $  7.50\r\n" +
                              "Item 5     10         $ 12.50\r\n" +
                              "Item 6     10kg       $ 12.00\r\n" +
                              "=============================\r\n" +
                              "Total Price           $ 93.75\r\n"; // total from CartTotalPriceTest()

            Assert.AreEqual(expected, Receipt.GetReceipt());
        }

        private static void FillUpCart()
        {
            ShoppingCart.NewCart();
            ShoppingCart.AddToCart(new GenericItem("Item 1", 2.50), 10); // unit
            ShoppingCart.AddToCart(new GenericItem("Item 2", 2.50, "kg"), 10.5); // weight

            ShoppingCart.AddToCart(new BuyXGetYFreeItem("Item 3", 1.50, 2, 1), 10); // unit
            ShoppingCart.AddToCart(new BuyXGetYFreeItem("Item 4", 1.50, "kg", 1.5, 2.5), 10); // weight

            ShoppingCart.AddToCart(new BuyXatPriceYItem("Item 5", 1.50, 2, 2.5), 10); // unit
            ShoppingCart.AddToCart(new BuyXatPriceYItem("Item 6", 1.50, "kg", 2.5, 3), 10); // weight
        }
    }
}
