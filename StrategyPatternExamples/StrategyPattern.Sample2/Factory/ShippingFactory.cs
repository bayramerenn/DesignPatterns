using StrategyPattern.Sample2.Enums;
using StrategyPattern.Sample2.Strategy;

namespace StrategyPattern.Sample2.Factory
{
    public class ShippingFactory : IShippingFactory
    {
        public IShippingStrategy CreateFreeShipping()
        {
            return new FreeShippingStrategy();
        }

        public IShippingStrategy CreateLocalShipping()
        {
            return new LocalShippingStrategy();
        }

        public IShippingStrategy CreateWorldWideShipping()
        {
            return new WorldwideShippingStrategy();
        }

        //public IShippingStrategy GetShippingService(ShippingMethods methods) 
        //{
        //    switch (methods)
        //    {
        //        case ShippingMethods.Free:
        //            return new FreeShippingStrategy();
        //        case ShippingMethods.Local:
        //            return new LocalShippingStrategy();
        //        case ShippingMethods.WorldWine:
        //            return new WorldwideShippingStrategy();
               
        //    }
        //    return new LocalShippingStrategy();

        //}
    }
}
