using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;

namespace DecaratorPattern.Sample1.Models
{
    public class CachedProductRepositoryDecorator : IProductRepository
    {
        private readonly IProductRepository _repository;
        private readonly IMemoryCache _cache;
        private const string KEY = "Product";
        private MemoryCacheEntryOptions _cacheEntryOptions;


        public CachedProductRepositoryDecorator(IProductRepository repository, IMemoryCache cache = null)
        {
            _repository = repository;
            _cache = cache;
            _cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(10));
        }
        public Product GetById(int id)
        {
            string key = KEY + id;

            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(_cacheEntryOptions);
                return _repository.GetById(id);
            });
        }

        public List<Product> List()
        {
            return _cache.GetOrCreate(KEY, entry =>
            {
                entry.SetOptions(_cacheEntryOptions);
                return _repository.List();
            });
        }
    }
}
