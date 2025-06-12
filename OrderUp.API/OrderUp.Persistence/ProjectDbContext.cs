using Microsoft.EntityFrameworkCore;
using OrderUp.Domain.Entities;


namespace OrderUp.Persistence;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
  {
  }

  public DbSet<User> Users => Set<User>();
  public DbSet<Product> Products => Set<Product>();
  public DbSet<ProductInventory> ProductInventory => Set<ProductInventory>();
  public DbSet<Order> Orders => Set<Order>();
  public DbSet<RequestLog> RequestLogs => Set<RequestLog>();
  public DbSet<Tenant> Tenants => Set<Tenant>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    //modelBuilder.Entity<ProductInventory>()
    //.HasOne(pi => pi.Product)
    //.WithMany(p => p.Inventory)
    //.HasForeignKey(pi => pi.ProductId);
  }
}