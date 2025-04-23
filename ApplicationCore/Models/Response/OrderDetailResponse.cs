namespace ApplicationCore.Models.Response;


public class OrderDetailResponse
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}
