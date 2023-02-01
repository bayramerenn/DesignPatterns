using StrategyPattern.Sample2.Strategy;

namespace StrategyPattern.Sample2.Factory
{
    public interface IShippingFactory
    {
        IShippingStrategy CreateFreeShipping();
        IShippingStrategy CreateLocalShipping();
        IShippingStrategy CreateWorldWideShipping();
    }
}
