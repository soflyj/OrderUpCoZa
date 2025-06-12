using OrderUp.Domain.Entities;

namespace OrderUp.Application.Interfaces;

public interface IOrderService
{
  //Task<IEnumerable<Order>> GetAllAsync(string tenantId);
  //Task<Order?> GetByIdAsync(Guid id, string tenantId);
  Task<Order> CreateAsync(Order order);
  Task<Order> UpdateAsync(Order order);
  //Task<bool> DeleteAsync(Guid id, string tenantId);
}
