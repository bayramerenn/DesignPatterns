namespace StrategyPattern.Sample2.Strategy
{
    public interface IShippingStrategy
    {
        decimal CalculateFinalTotal(decimal orderTotal);
    }
}