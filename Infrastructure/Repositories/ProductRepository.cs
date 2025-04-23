using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ProductRepository:BaseRepository<Product>,IProductRepository
{
    public ProductRepository(EcommerceDbContext dbContext) : base(dbContext)
    {
    }
}