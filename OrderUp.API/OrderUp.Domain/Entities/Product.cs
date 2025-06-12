using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;

namespace OrderUp.Domain.Entities;

public class Product
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  [Column(TypeName = "decimal(18,2)")]
  public decimal Price { get; set; }
  public List<string> Images { get; set; } = new();
  public List<ProductInventory> Inventory { get; set; } = new();
  public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
}