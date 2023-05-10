using Kshop.Infra.Persistence.EntityFrameWork.Customers.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Kshop.Infra.Persistence.EntityFrameWork;
public class KShopDbContextFactory : IDesignTimeDbContextFactory<KShopDbContext>
{
    public KShopDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<KShopDbContext>()
            .UseSqlServer("Data Source=.;Initial Catalog=KShopTestDb;Integrated Security=true;TrustServerCertificate=True",
            options => options.MigrationsAssembly(typeof(CustomerConfiguration).Assembly.FullName));
        return new KShopDbContext(builder.Options);
    }
}
