namespace StrategyPattern.Sample3.Strategy
{
    public class DeepFryingService : ICookingStrategyService
    {
        public string Cook(string food)
        {
            return $"Cooking {food} by deep frying it";
        }
    }
}
