using Microsoft.EntityFrameworkCore;

namespace DecaratorPattern.Sample1.Models
{
    public class EfProductRepository : EfRepository<Product>, IProductRepository
    {
        public EfProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
