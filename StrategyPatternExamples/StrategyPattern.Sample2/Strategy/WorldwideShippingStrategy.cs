namespace StrategyPattern.Sample2.Strategy
{
    public class WorldwideShippingStrategy : IShippingStrategy
    {
        public decimal CalculateFinalTotal(decimal orderTotal)
        {
            return orderTotal + 50;
        }
    }
}
