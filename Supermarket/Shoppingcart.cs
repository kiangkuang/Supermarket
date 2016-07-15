using System;
using System.Collections.Generic;
using System.Text;

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

        public static string Checkout()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name\t  Qty\t  Price");
            foreach (KeyValuePair<GenericItem, double> itemQuantityPair in Cart)
            {
                sb.AppendLine(itemQuantityPair.Key.Name + "\tx "
                    + itemQuantityPair.Value + "\t: "
                    + MoneyFormat(itemQuantityPair.Key.GetPrice(itemQuantityPair.Value)));
            }
            sb.AppendLine("========================");
            sb.AppendLine("Total\t\t: " + MoneyFormat(GetTotalPrice()));

            return sb.ToString();
        }

        private static string MoneyFormat(double money)
        {
            return Convert.ToDecimal(money).ToString("C");
        }
    }
}
