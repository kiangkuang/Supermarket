namespace Supermarket
{
    public class GenericItem
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string Unit { get; set; }

        public GenericItem(string name, double unitPrice)
        {
            this.Name = name;
            this.UnitPrice = unitPrice;
        }

        // items with weight as unit
        public GenericItem(string name, double unitPrice, string unit)
        {
            this.Name = name;
            this.UnitPrice = unitPrice;
            this.Unit = unit;
        }

        public virtual double GetPrice(double qty)
        {
            return qty * UnitPrice;
        }
    }
}
