using StrategyPattern.Sample1.Operators;

namespace StrategyPattern.Sample1.Strategy
{
    public interface IMathStrategy
    {
        int Calculate(int a, int b, Operator op);
    }
}
