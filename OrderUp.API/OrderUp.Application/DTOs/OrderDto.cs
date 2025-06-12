namespace OrderUp.Application.DTOs;

public class OrderDto
{
  public Guid UserId { get; set; }
  public List<Guid> ProductIds { get; set; } = new();
}
