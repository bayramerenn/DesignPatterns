namespace StrategyPattern.Sample3.Strategy
{
    public class GrillingService : ICookingStrategyService
    {
        public string Cook(string food)
        {
            return $"Cooking {food} by grilling it";
        }
    }
}