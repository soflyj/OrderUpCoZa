using OrderUp.Domain.Entities;

namespace OrderUp.Application.Interfaces;

public interface ITenantService
{
  //Task<IEnumerable<Order>> GetAllAsync(string tenantId);
  //Task<Order?> GetByIdAsync(Guid id, string tenantId);
  Task<Tenant> CreateAsync(Tenant tenant);
  Task<Tenant> UpdateAsync(Tenant tenant);
  //Task<bool> DeleteAsync(Guid id, string tenantId);
}
