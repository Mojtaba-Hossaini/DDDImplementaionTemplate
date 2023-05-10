namespace KShop.Core.Domain.Discounts;

public interface IDiscountRepository
{
    Task Create(Discount discount, CancellationToken cancellationToken);
    Task<Discount> GetById(long id, CancellationToken cancellationToken);
}
