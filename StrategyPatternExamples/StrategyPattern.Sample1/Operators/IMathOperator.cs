namespace StrategyPattern.Sample1.Operators
{
    public interface IMathOperator
    {
        Operator Operator { get; }
        int Calculate(int a, int b);
    }
}
