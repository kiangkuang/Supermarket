namespace Supermarket
{
    public class BuyXatPriceYItem : GenericItem
    {
        public double BuyX { get; set; }
        public double PriceY { get; set; }

        public BuyXatPriceYItem(string name, double unitPrice, double buyX, double priceY)
            : base(name, unitPrice)
        {
            this.BuyX = buyX;
            this.PriceY = priceY;
        }

        // items with weight as unit
        public BuyXatPriceYItem(string name, double unitPrice, string unit, double buyX, double priceY)
            : base(name, unitPrice, unit)
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
