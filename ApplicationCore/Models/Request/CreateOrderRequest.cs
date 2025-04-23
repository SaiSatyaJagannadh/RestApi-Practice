namespace ApplicationCore.Models.Request;

public class CreateOrderRequest
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public int PaymentMethodId { get; set; }
    public string PaymentName { get; set; }
    public string ShippingAddress { get; set; }
    public string ShippingMethod { get; set; }
    public decimal BillAmount { get; set; }
    public string OrderStatus { get; set; }
    public List<OrderDetailRequest> OrderDetails { get; set; }
}






