using DecaratorPattern.Sample1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis.Extensions.Core.Abstractions;

namespace DecaratorPattern.Sample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IRedisClientFactory _redisClientFactory;
        private readonly IRedisDatabase redisDatabase;
        private readonly IRedisClient _redisClient;
        public ProductsController(IProductRepository productRepository, IRedisClient redisClient = null)
        {
            _productRepository = productRepository;
            redisDatabase = redisClient.GetDb(0);
            _redisClient = redisClient;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
          

           //var data = await redisDatabase.AddAsync("product1", new Product { ad = "Bayram" });
            return Ok(_productRepository.List());
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
           

            var product = await redisDatabase.GetAsync<Product>("product1");
            return Ok(product);
        }

        public class Product
        {
            public string ad { get; set; }
        }
    }
}
