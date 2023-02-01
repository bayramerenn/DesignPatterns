namespace StrategyPattern.Sample2.Models
{
    public class CheckoutModel
    {
        public int SelectedMethod { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal FinalTotal { get; set; }

        public List<Shipping> ShippingMethods { get; set; } = new List<Shipping>();
    }
}