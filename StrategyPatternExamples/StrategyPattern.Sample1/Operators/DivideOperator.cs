namespace StrategyPattern.Sample1.Operators
{
    public class DivideOperator : IMathOperator
    {
        public Operator Operator => Operator.Divide;

        public int Calculate(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }

            return a / b;
        }
    }
}
