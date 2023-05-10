using Kshop.Infra.Persistence.EntityFrameWork.Contracts;
using KShop.Core.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Kshop.Infra.Persistence.EntityFrameWork.Orders;
public class OrderRepository : BaseRepository<Order, long>, IOrderRepository
{
    public OrderRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task Create(Order order, CancellationToken cancellationToken)
    {
        DbSet.Add(order);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Order> GetById(long id, CancellationToken cancellationToken) => 
        await DbSet.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
}
