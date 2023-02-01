namespace StrategyPattern.Sample3.Strategy
{
    public class RoastingService : ICookingStrategyService
    {
        public string Cook(string food)
        {
            return $"Cooking {food} by roasting it";
        }
    }
}