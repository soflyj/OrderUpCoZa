using OrderUp.Application.Interfaces;
using OrderUp.Domain.Entities;
using OrderUp.Persistence;

namespace TenantUp.Application.Services;

public class TenantService : ITenantService
{
  private readonly ApplicationDbContext _context;

  public TenantService(ApplicationDbContext context)
  {
    _context = context;
  }

  //public async Task<IEnumerable<Tenant>> GetAllAsync(string tenantId) =>
  //    _context.Tenants.Where(o => o.TenantId == tenantId).ToList();

  //public async Task<Tenant?> GetByIdAsync(Guid id, string tenantId) =>
  //    _context.Tenants.FirstOrDefault(o => o.Id == id && o.TenantId == tenantId);

  public async Task<Tenant> CreateAsync(Tenant tenant)
  {
    _context.Tenants.Add(tenant);
    await _context.SaveChangesAsync();
    return tenant;
  }

  public async Task<Tenant> UpdateAsync(Tenant tenant)
  {
    _context.Tenants.Update(tenant);
    await _context.SaveChangesAsync();
    return tenant;
  }

  //public async Task<bool> DeleteAsync(Guid id, string tenantId)
  //{
  //  var Tenant = await GetByIdAsync(id, tenantId);
  //  if (Tenant == null) return false;
  //  _context.Tenants.Remove(Tenant);
  //  await _context.SaveChangesAsync();
  //  return true;
  //}
}
