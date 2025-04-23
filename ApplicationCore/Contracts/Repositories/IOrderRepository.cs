using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IOrderRepository: IRepository<Order>
{
    Task<IEnumerable<Order>> GetAllWithDetailsAsync();
    Task<Order> GetByCustomerIdAsync(int customerId);
}

