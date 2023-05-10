using Kshop.Infra.Persistence.EntityFrameWork.Contracts;
using KShop.Core.Domain.Discounts;
using Microsoft.EntityFrameworkCore;

namespace Kshop.Infra.Persistence.EntityFrameWork.Discounts;
public class DiscountRepository : BaseRepository<Discount, long>, IDiscountRepository
{
    public DiscountRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task Create(Discount discount, CancellationToken cancellationToken)
    {
        DbSet.Add(discount);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Discount> GetById(long id, CancellationToken cancellationToken) =>
        await DbSet.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
}
