using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderUp.Application.Interfaces;
using OrderUp.Domain.Entities;

namespace OrderUp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
  private readonly IOrderService _service;

  public OrdersController(IOrderService service)
  {
    _service = service;
  }

    //[HttpGet]
    //public async Task<IActionResult> GetAll(int id)
    //{    
    //    Ok(await _service.GetByIdAsync(id));
    //}

    //[HttpGet("{id}")]
    //public async Task<IActionResult> Get(Guid id, string tenantId)
    //{
    //    var order = await _service.GetByIdAsync(id, tenantId);
    //    return order is null ? NotFound() : Ok(order);
    //}

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(Order order)
    {
        await _service.CreateAsync(order);
        return Ok(order);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Order order)
    {
        if (id != order.Id) return BadRequest();
        await _service.UpdateAsync(order);
        return NoContent();
    }

    //[Authorize]
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(Guid id)
    //{
    //    await _service.DeleteOrderAsync(id);
    //    return NoContent();
    //}
}
