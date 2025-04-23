using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    private readonly EcommerceDbContext _context;

    
    public OrderRepository(EcommerceDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }

    

    public async Task<IEnumerable<Order>> GetAllWithDetailsAsync()
    {
        return await _context.Orders.Include(o => o.OrderDetails).ToListAsync();
    }

    public async Task<Order> GetByCustomerIdAsync(int customerId)
    {
        return await _context.Orders.Include(o => o.OrderDetails)
            .FirstOrDefaultAsync(o => o.CustomerId == customerId);
    }
}


