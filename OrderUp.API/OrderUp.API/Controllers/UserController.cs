using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderUp.Application.Interfaces;
using OrderUp.Domain.Entities;

namespace OrderUp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  private readonly IUserService _service;

  public UserController(IUserService service)
  {
    _service = service;
  }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetAll(string id) =>
    //    Ok(await _service.GetAllbyTenantAsync(id));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id, string tenantId)
    {
        var user = await _service.GetByIdAsync(id, tenantId);
        return user is null ? NotFound() : Ok(user);
    }

    [Authorize(Roles = "Vendor")]
    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        await _service.CreateAsync(user);
        return Ok(user);
    }

    [Authorize(Roles = "Vendor")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, User user)
    {
        if (id != user.Id) return BadRequest();
        await _service.UpdateAsync(user);
        return NoContent();
    }

    //[Authorize(Roles = "Vendor")]
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(Guid id)
    //{
    //    await _service.DeleteProductAsync(id);
    //    return NoContent();
    //}
}
