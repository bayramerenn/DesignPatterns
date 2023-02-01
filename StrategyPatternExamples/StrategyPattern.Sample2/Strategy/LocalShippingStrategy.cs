namespace StrategyPattern.Sample2.Strategy
{
    public class LocalShippingStrategy : IShippingStrategy
    {
        public decimal CalculateFinalTotal(decimal orderTotal)
        {
            return orderTotal + 10;
        }
    }
}
