using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IOrderDetailRepository: IRepository<OrderDetail>
{
    Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId);

}

