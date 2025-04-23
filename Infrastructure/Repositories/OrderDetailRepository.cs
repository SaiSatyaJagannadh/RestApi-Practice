using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderDetailRepository: BaseRepository<OrderDetail>, IOrderDetailRepository
{
    private readonly EcommerceDbContext _context;

    
    public OrderDetailRepository(EcommerceDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId)
    {
        return await _context.OrderDetails
            .Where(d => d.OrderId == orderId)
            .ToListAsync();
    }
    
    

}