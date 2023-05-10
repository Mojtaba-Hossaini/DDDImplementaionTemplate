namespace KShop.Core.Domain.Shares;
public interface IShareRepository
{
    Task Create(Share share, CancellationToken cancellationToken);
    Task<Share> GetById(long id, CancellationToken cancellationToken);
    Task<Share> GetByProductId(long productId, CancellationToken cancellationToken);
}
