using OrderUp.Domain.Entities;

namespace OrderUp.Application.DTOs;

public class ProductDto
{
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public List<string> Images { get; set; } = new();
  public List<ProductInventory> Inventory { get; set; } = new();
}
