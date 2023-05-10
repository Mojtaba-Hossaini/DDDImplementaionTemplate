namespace KShop.Core.Domain.Shipments;
public interface IShipmentRepository
{
    Task Create(Shipment shipment, CancellationToken cancellationToken);
    Task<Shipment> GetById(long id, CancellationToken cancellationToken);
}
