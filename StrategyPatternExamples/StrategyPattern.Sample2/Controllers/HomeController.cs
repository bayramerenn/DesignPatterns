using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Sample2.Factory;
using StrategyPattern.Sample2.Models;
using StrategyPattern.Sample2.Strategy.Context;

namespace StrategyPattern.Sample2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IShippingContext _shippingContext;
        private readonly IShippingFactory _shippingFactory;

        public HomeController(IShippingContext shippingContext, IShippingFactory shippingFactory = null)
        {
            _shippingContext = shippingContext;
            _shippingFactory = shippingFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(GetOrderDetails());
        }

        [HttpPost("CheckoutCalculater")]
        public IActionResult CheckoutCalculater(CheckoutModel checkoutModel)
        {
            checkoutModel.ShippingMethods = GetShippingMethods().Where(x => x.Id == checkoutModel.SelectedMethod).ToList();

            switch (checkoutModel.SelectedMethod)
            {
                case 1:
                    _shippingContext.SetStrategy(_shippingFactory.CreateFreeShipping());
                    break;

                case 2:
                    _shippingContext.SetStrategy(_shippingFactory.CreateLocalShipping());
                    break;

                case 3:
                    _shippingContext.SetStrategy(_shippingFactory.CreateWorldWideShipping());
                    break;

                default:
                    break;
            }

            checkoutModel.FinalTotal = _shippingContext.ExecuteStrategy(checkoutModel.OrderTotal);

            return Ok(checkoutModel);
        }

        private CheckoutModel GetOrderDetails()
        {
            var model = new CheckoutModel()
            {
                OrderTotal = 100.00m,
                ShippingMethods = GetShippingMethods()
            };
            return model;
        }

        private List<Shipping> GetShippingMethods()
        {
            return new List<Shipping>()
                {
                    new Shipping()
                    {
                        Id = 1,
                        Name="Free Shipping ($0.00)"
                    },
                    new Shipping() {
                        Id = 2,
                        Name="Local Shipping ($10.00)"
                    },
                    new Shipping() {
                        Id = 3,
                        Name="Worldwide Shipping ($50.00)"
                    }
                };
        }
    }
}