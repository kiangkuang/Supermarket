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

        public static string GetReceipt()
        {
            StringBuilder sb = new StringBuilder();
            BuildReceiptHeader(sb);
            foreach (KeyValuePair<GenericItem, double> itemQuantityPair in Cart)
            {
                BuildReceiptItem(sb, itemQuantityPair);
            }
            BuildReceiptFooter(sb);

            return sb.ToString();
        }

        private static void BuildReceiptHeader(StringBuilder sb)
        {
            sb.AppendLine(String.Format("{0,-10} {1,-10} {2,7}", "Name", "Quantity", "Price"));
            sb.AppendLine("-----------------------------");
        }

        private static void BuildReceiptItem(StringBuilder sb, KeyValuePair<GenericItem, double> itemQuantityPair)
        {
            string itemName = itemQuantityPair.Key.Name;
            string qty = itemQuantityPair.Value + itemQuantityPair.Key.Unit;
            string price = ConvertDecimalFormat(itemQuantityPair.Key.GetPrice(itemQuantityPair.Value));
            sb.AppendLine(String.Format("{0,-10} {1,-10} {2,1} {3,5}", itemName, qty, "$", price));
        }

        private static void BuildReceiptFooter(StringBuilder sb)
        {
            sb.AppendLine("=============================");
            sb.AppendLine(String.Format("{0,-21} {1,1} {2,5}", "Total Price", "$", ConvertDecimalFormat(GetTotalPrice())));
        }

        private static string ConvertDecimalFormat(double value)
        {
            return Convert.ToDecimal(value).ToString("#.00");
        }
    }
}
