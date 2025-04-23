using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepo;

    public OrderService(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
    {
        var orders = await _orderRepo.GetAllWithDetailsAsync();
        return orders.Select(MapToResponse);
    }

    public async Task<OrderResponse> GetOrderByCustomerIdAsync(int customerId)
    {
        var order = await _orderRepo.GetByCustomerIdAsync(customerId);
        return order != null ? MapToResponse(order) : null;
    }

    public async Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request)
    {
        var order = new Order
        {
            CustomerId = request.CustomerId,
            CustomerName = request.CustomerName,
            PaymentMethodId = request.PaymentMethodId,
            PaymentName = request.PaymentName,
            ShippingAddress = request.ShippingAddress,
            ShippingMethod = request.ShippingMethod,
            BillAmount = request.BillAmount,
            OrderStatus = request.OrderStatus,
            OrderDate = DateTime.UtcNow,
            OrderDetails = request.OrderDetails.Select(d => new OrderDetail
            {
                ProductId = d.ProductId,
                ProductName = d.ProductName,
                Qty = d.Qty,
                Price = d.Price,
                Discount = d.Discount
            }).ToList()
        };

        _orderRepo.Insert(order);
        return MapToResponse(order);
    }

    public async Task<OrderResponse> UpdateOrderAsync(UpdateOrderRequest request)
    {
        var order = _orderRepo.GetById(request.Id);
        if (order == null) throw new Exception("Order not found");

        order.CustomerName = request.CustomerName;
        order.ShippingAddress = request.ShippingAddress;
        order.ShippingMethod = request.ShippingMethod;
        order.OrderStatus = request.OrderStatus;
        order.PaymentName = request.PaymentName;
        order.PaymentMethodId = request.PaymentMethodId;
        order.BillAmount = request.BillAmount;

        // Update OrderDetails by replacing all
        order.OrderDetails = request.OrderDetails.Select(d => new OrderDetail
        {
            ProductId = d.ProductId,
            ProductName = d.ProductName,
            Qty = d.Qty,
            Price = d.Price,
            Discount = d.Discount
        }).ToList();

        _orderRepo.Update(order);
        return MapToResponse(order);
    }

    public async Task DeleteOrderAsync(int orderId)
    {
        _orderRepo.Delete(orderId);
    }

    private OrderResponse MapToResponse(Order order)
    {
        return new OrderResponse
        {
            OrderId = order.Id,
            CustomerId = order.CustomerId,
            CustomerName = order.CustomerName,
            PaymentName = order.PaymentName,
            ShippingAddress = order.ShippingAddress,
            ShippingMethod = order.ShippingMethod,
            BillAmount = order.BillAmount,
            OrderStatus = order.OrderStatus,
            OrderDate = order.OrderDate,
            Details = order.OrderDetails?.Select(d => new OrderDetailResponse
            {
                ProductId = d.ProductId,
                ProductName = d.ProductName,
                Qty = d.Qty,
                Price = d.Price,
                Discount = d.Discount
            }).ToList()
        };
    }
}
