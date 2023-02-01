using StrategyPattern.Sample1.Operators;

namespace StrategyPattern.Sample1.Strategy
{
    public class MathStrategy : IMathStrategy
    {
        public readonly IEnumerable<IMathOperator> _operators;

        public MathStrategy(IEnumerable<IMathOperator> operators)
        {
            _operators = operators;
        }

        public int Calculate(int a, int b, Operator op)
        {
            return _operators.FirstOrDefault(x => x.Operator == op)?.Calculate(a, b) ?? throw new ArgumentNullException(nameof(op));
        }
    }
}