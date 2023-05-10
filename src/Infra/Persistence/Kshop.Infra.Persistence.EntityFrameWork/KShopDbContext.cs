using Kshop.Infra.Persistence.EntityFrameWork.Customers.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Kshop.Infra.Persistence.EntityFrameWork;
public class KShopDbContext : DbContext
{
    public KShopDbContext(DbContextOptions<KShopDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
