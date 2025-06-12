namespace OrderUp.Domain.Entities;

public class RequestLog
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string? IPAddress { get; set; }
  public string? Location { get; set; }
  public string? Path { get; set; }
  public string? Method { get; set; }
  public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
