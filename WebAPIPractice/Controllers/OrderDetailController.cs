using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIPractice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailController : ControllerBase
{
    private readonly IOrderDetailService _detailService;

    public OrderDetailController(IOrderDetailService detailService)
    {
        _detailService = detailService;
    }

    [HttpGet("order/{orderId}")]
    public async Task<IActionResult> GetByOrderId(int orderId)
    {
        var details = await _detailService.GetDetailsByOrderIdAsync(orderId);
        return Ok(details);
    }
}
