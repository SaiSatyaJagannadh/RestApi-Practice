using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CategoryRepository:BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(EcommerceDbContext dbContext) : base(dbContext)
    {
    }
}