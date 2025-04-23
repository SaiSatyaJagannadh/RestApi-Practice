namespace ApplicationCore.Models.Response;

public class OrderResponse
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string PaymentName { get; set; }
    public string ShippingAddress { get; set; }
    public string ShippingMethod { get; set; }
    public decimal BillAmount { get; set; }
    public string OrderStatus { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderDetailResponse> Details { get; set; }
}