using KShop.Core.Domain.Shipments;

namespace KShop.Application.DomainApplication.Contracts.Shipments.Queries;
public class GetShipmentQueryResult
{
    public long OrderId { get; set; }
    public string ShipmentType { get; set; }
    public bool DeliverToCustomer { get; set; }
}
