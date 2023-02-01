namespace StrategyPattern.Sample2.Strategy.Context
{
    public class ShippingContext : IShippingContext
    {
        private IShippingStrategy? _shippingStrategy;

        public decimal ExecuteStrategy(decimal orderTotal)
        {
            return _shippingStrategy!.CalculateFinalTotal(orderTotal);
        }

        public void SetStrategy(IShippingStrategy shippingStrategy)
        {
            _shippingStrategy = shippingStrategy;
        }
    }
}
