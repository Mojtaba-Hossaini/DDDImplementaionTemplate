using Kshop.Infra.Persistence.EntityFrameWork.Contracts;
using KShop.Core.Domain.Shares;
using Microsoft.EntityFrameworkCore;

namespace Kshop.Infra.Persistence.EntityFrameWork.Shares;

public class ShareRepository : BaseRepository<Share, long>, IShareRepository
{
    public ShareRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task Create(Share share, CancellationToken cancellationToken)
    {
        DbSet.Add(share);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Share> GetById(long id, CancellationToken cancellationToken) =>
        await DbSet.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task<Share> GetByProductId(long productId, CancellationToken cancellationToken) =>
        await DbSet.FirstOrDefaultAsync(c => c.ProductId == productId, cancellationToken);
}
