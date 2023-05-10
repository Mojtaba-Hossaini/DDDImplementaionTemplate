using KShop.Infra.Query.EntityFrameWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace KShop.Infra.Query.EntityFrameWork;
public class KShopQueryDbContext : DbContext
{
    public KShopQueryDbContext(DbContextOptions<KShopQueryDbContext> options) : base(options)
    {
        
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
}
