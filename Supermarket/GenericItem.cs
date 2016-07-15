namespace Supermarket
{
    public class GenericItem
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }

        public GenericItem(string name, double unitPrice)
        {
            this.Name = name;
            this.UnitPrice = unitPrice;
        }

        public virtual double GetPrice(double qty)
        {
            return qty * UnitPrice;
        }
    }
}
