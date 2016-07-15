using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public class Receipt
    {
        public static string GetReceipt()
        {
            StringBuilder sb = new StringBuilder();
            BuildReceiptHeader(sb);
            foreach (KeyValuePair<GenericItem, double> itemQuantityPair in ShoppingCart.Cart)
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
            sb.AppendLine(String.Format("{0,-21} {1,1} {2,5}", "Total Price", "$", ConvertDecimalFormat(ShoppingCart.GetTotalPrice())));
        }

        private static string ConvertDecimalFormat(double value)
        {
            return Convert.ToDecimal(value).ToString("#.00");
        }
    }
}