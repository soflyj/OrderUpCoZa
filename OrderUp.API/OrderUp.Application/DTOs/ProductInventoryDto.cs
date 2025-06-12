using OrderUp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OrderUp.Application.DTOs;

public class ProductInventory
{
    public int Id { get; set; }
    [Required]
    public string Key { get; set; }  // e.g., Size or Variant name
    public int Value { get; set; }   // e.g., Stock count
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}
