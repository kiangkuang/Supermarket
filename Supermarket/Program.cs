using System;

namespace Supermarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ShoppingCart.NewCart();
            ShoppingCart.AddToCart(new GenericItem("Item 1", 2.50), 10); // unit
            ShoppingCart.AddToCart(new GenericItem("Item 2", 2.50, "kg"), 10.5); // weight

            ShoppingCart.AddToCart(new BuyXGetYFreeItem("Item 3", 1.50, 2, 1), 10); // unit
            ShoppingCart.AddToCart(new BuyXGetYFreeItem("Item 4", 1.50, "kg", 1.5, 2.5), 10); // weight

            ShoppingCart.AddToCart(new BuyXatPriceYItem("Item 5", 1.50, 2, 2.5), 10); // unit
            ShoppingCart.AddToCart(new BuyXatPriceYItem("Item 6", 1.50, "kg", 2.5, 3), 10); // weight

            Console.Write(ShoppingCart.GetReceipt());
        }
    }
}
