using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Sample3.Strategy;

namespace StrategyPattern.Sample3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ServiceResolver _serviceResolver;

        public ValuesController(ServiceResolver serviceResolver)
        {
            _serviceResolver = serviceResolver;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var service = _serviceResolver(CookingType.Grill);

            return Ok(service.Cook("Tavuk"));
        }
    }
}