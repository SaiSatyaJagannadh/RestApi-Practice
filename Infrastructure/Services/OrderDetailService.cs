using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.Response;

namespace Infrastructure.Services;

public class OrderDetailService : IOrderDetailService
{
    private readonly IOrderDetailRepository _detailRepo;

    public OrderDetailService(IOrderDetailRepository detailRepo)
    {
        _detailRepo = detailRepo;
    }

    public async Task<IEnumerable<OrderDetailResponse>> GetDetailsByOrderIdAsync(int orderId)
    {
        var details = await _detailRepo.GetByOrderIdAsync(orderId);
        return details.Select(d => new OrderDetailResponse
        {
            ProductId = d.ProductId,
            ProductName = d.ProductName,
            Qty = d.Qty,
            Price = d.Price,
            Discount = d.Discount
        });
    }
}
