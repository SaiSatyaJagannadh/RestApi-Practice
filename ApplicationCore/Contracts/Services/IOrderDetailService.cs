using ApplicationCore.Models.Response;

namespace ApplicationCore.Contracts.Services;

public interface IOrderDetailService
{
    Task<IEnumerable<OrderDetailResponse>> GetDetailsByOrderIdAsync(int orderId);

}


