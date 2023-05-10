using KShop.Infra.Query.EntityFrameWork.Entities;

namespace KShop.Infra.Query.EntityFrameWork.Contracts;
public interface IShipmentQueryRepository
{
    Task<Shipment> GetShipmentById(long orderId, CancellationToken cancellationToken);
}
