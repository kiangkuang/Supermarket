using System.Collections.Generic;

namespace Supermarket
{
    public class ShoppingCart
    {
        public static Dictionary<GenericItem, double> Cart = new Dictionary<GenericItem, double>();

        public static void NewCart()
        {
            Cart = new Dictionary<GenericItem, double>();
        }

        public static void AddToCart(GenericItem item, double qty)
        {
            double oldQty;
            if (Cart.TryGetValue(item, out oldQty))
            {
                // item already exists in cart
                Cart.Remove(item);
                Cart.Add(item, oldQty + qty);
            }
            else
            {
                // item not in cart yet
                Cart.Add(item, qty);
            }
        }

        public static int GetNumUniqueItems()
        {
            return Cart.Count;
        }

        public static double GetTotalPrice()
        {
            double sum = 0;
            foreach (KeyValuePair<GenericItem, double> itemQuantityPair in Cart)
            {
                sum += itemQuantityPair.Key.GetPrice(itemQuantityPair.Value);
            }
            return sum;
        }
    }
}
