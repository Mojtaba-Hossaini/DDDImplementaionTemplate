using KShop.Core.Domain.Shipments;

namespace KShopTestUtil.Shipments;
public class ShipmentTestBuilder
{
    public ShipmentTestBuilder()
    {
        Id = 1;
        OrderId = 1;
        ShipmentType = ShipmentType.FastExpress;
    }
    public long Id { get; set; }
    public long OrderId { get; set; }
    public ShipmentType ShipmentType { get; set; }
    public bool DeliverToCustomer { get; set; }
    public Shipment Build() =>
        Shipment.Build(Id, OrderId, ShipmentType);
}
