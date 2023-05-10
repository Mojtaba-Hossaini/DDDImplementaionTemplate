using Microsoft.EntityFrameworkCore;

namespace Kshop.Infra.Persistence.EntityFrameWork.Contracts;
public class BaseRepository<TEntity, TKey> where TEntity : class
{
    protected DbContext Context;

    protected DbSet<TEntity> DbSet;
    public BaseRepository(DbContext dbContext)
    {
        DbSet = dbContext.Set<TEntity>();
        Context = dbContext;
    }
}
