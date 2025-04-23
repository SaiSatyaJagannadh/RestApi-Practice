using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.Contracts.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderResponse>> GetAllOrdersAsync();
    Task<OrderResponse> GetOrderByCustomerIdAsync(int customerId);
    Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request);
    Task<OrderResponse> UpdateOrderAsync(UpdateOrderRequest request);
    Task DeleteOrderAsync(int orderId);
}

