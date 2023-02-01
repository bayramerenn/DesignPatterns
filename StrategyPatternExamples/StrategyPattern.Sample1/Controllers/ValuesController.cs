using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Sample1.Operators;
using StrategyPattern.Sample1.Strategy;

namespace StrategyPattern.Sample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IMathStrategy _mathStrategy;

        public ValuesController(IMathStrategy mathStrategy)
        {
            _mathStrategy = mathStrategy;
        }

        [HttpGet]
        public IActionResult Get(int a,int b,Operator @operator)
        {
            int result = 0;
            switch (@operator)
            {
                case Operator.Add:
                    result = _mathStrategy.Calculate(a, b, Operator.Add);
                    break;
                case Operator.Substract:
                    result = _mathStrategy.Calculate(a, b, Operator.Substract);
                    break;
                case Operator.Multiple:
                    result = _mathStrategy.Calculate(a, b, Operator.Multiple);
                    break;
                case Operator.Divide:
                    result = _mathStrategy.Calculate(a, b, Operator.Divide);
                    break;
                default:
                    result = 0;
                    break;
            }
            
            return Ok(result);
        }
    }
}
