namespace KShop.Core.Domain.Orders;
public interface IOrderRepository
{
    Task Create(Order order, CancellationToken cancellationToken);
    Task<Order> GetById(long id, CancellationToken cancellationToken);
}
