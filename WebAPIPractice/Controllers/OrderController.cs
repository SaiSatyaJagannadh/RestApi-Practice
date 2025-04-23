using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIPractice.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _orderService.GetAllOrdersAsync());

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetByCustomerId(int customerId)
        => Ok(await _orderService.GetOrderByCustomerIdAsync(customerId));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        => Ok(await _orderService.CreateOrderAsync(request));

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderRequest request)
        => Ok(await _orderService.UpdateOrderAsync(request));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _orderService.DeleteOrderAsync(id);
        return NoContent();
    }
}
