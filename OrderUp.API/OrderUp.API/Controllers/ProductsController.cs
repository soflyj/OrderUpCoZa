using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderUp.Application.Interfaces;
using OrderUp.Domain.Entities;

namespace OrderUp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var product = await _service.GetByIdAsync(id);
        return product is null ? NotFound() : Ok(product);
    }

    [Authorize(Roles = "Vendor")]
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await _service.CreateAsync(product);
        return Ok(product);
    }

    [Authorize(Roles = "Vendor")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Product product)
    {
        if (id != product.Id) return BadRequest();
        await _service.UpdateAsync(product);
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
