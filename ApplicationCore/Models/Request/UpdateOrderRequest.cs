namespace ApplicationCore.Models.Request;


public class UpdateOrderRequest : CreateOrderRequest
{
    public int Id { get; set; }
}