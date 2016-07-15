namespace Supermarket
{
    public class BuyXGetYFreeItem : GenericItem
    {
        public double BuyX { get; set; }
        public double GetY { get; set; }

        public BuyXGetYFreeItem(string name, double unitPrice, double buyX, double getY)
            : base(name, unitPrice)
        {
            this.BuyX = buyX;
            this.GetY = getY;
        }

        // items with weight as unit
        public BuyXGetYFreeItem(string name, double unitPrice, string unit, double buyX, double getY)
            : base(name, unitPrice, unit)
        {
            this.BuyX = buyX;
            this.GetY = getY;
        }

        public override double GetPrice(double qty)
        {
            return GetDiscountedTotalPrice(qty) + GetUndiscountedTotalPrice(qty);
        }

        private double GetDiscountedTotalPrice(double qty)
        {
            return (int)(qty / (BuyX + GetY)) * (BuyX * UnitPrice);
        }

        private double GetUndiscountedTotalPrice(double qty)
        {
            return qty % (BuyX + GetY) * UnitPrice;
        }
    }
}
