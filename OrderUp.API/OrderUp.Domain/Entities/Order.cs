namespace OrderUp.Domain.Entities;

public class Order
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public Guid UserId { get; set; }
  public List<Product> ProductIds { get; set; } = new();
  public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
}
