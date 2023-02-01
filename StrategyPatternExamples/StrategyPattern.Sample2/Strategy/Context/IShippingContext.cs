namespace StrategyPattern.Sample2.Strategy.Context
{
    public interface IShippingContext
    {
        void SetStrategy(IShippingStrategy shippingStrategy);

        decimal ExecuteStrategy(decimal orderTotal);
    }
}