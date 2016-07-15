namespace Supermarket
{
    public class GenericItem
    {
        protected string Name;
        protected double UnitPrice;

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
