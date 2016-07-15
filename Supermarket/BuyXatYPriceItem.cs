namespace Supermarket
{
    public class BuyXatYPriceItem : GenericItem
    {
        protected double BuyX;
        protected double PriceY;

        public BuyXatYPriceItem(string name, double unitPrice, double buyX, double priceY)
            : base(name, unitPrice)
        {
            this.BuyX = buyX;
            this.PriceY = priceY;
        }

        public override double GetPrice(double qty)
        {
            return GetDiscountedTotalPrice(qty) + GetUndiscountedTotalPrice(qty);
        }

        private double GetDiscountedTotalPrice(double qty)
        {
            return (int)(qty / BuyX) * PriceY;
        }

        private double GetUndiscountedTotalPrice(double qty)
        {
            return qty % BuyX * UnitPrice;
        }
    }
}
