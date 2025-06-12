using OrderUp.Application.Interfaces;
using OrderUp.Domain.Entities;
using OrderUp.Persistence;

namespace OrderUp.Application.Services;

public class OrderService : IOrderService
{
  private readonly ApplicationDbContext _context;

  public OrderService(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Order>> GetAllAsync(string tenantId) =>
      _context.Orders.Where(o => o.TenantId == tenantId).ToList();

  public async Task<Order?> GetByIdAsync(Guid id, string tenantId) =>
      _context.Orders.FirstOrDefault(o => o.Id == id && o.TenantId == tenantId);

  public async Task<Order> CreateAsync(Order order)
  {
    _context.Orders.Add(order);
    await _context.SaveChangesAsync();
    return order;
  }

  public async Task<Order> UpdateAsync(Order order)
  {
    _context.Orders.Update(order);
    await _context.SaveChangesAsync();
    return order;
  }

  public async Task<bool> DeleteAsync(Guid id, string tenantId)
  {
    var order = await GetByIdAsync(id, tenantId);
    if (order == null) return false;
    _context.Orders.Remove(order);
    await _context.SaveChangesAsync();
    return true;
  }
}
