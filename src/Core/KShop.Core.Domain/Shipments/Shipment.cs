namespace KShop.Core.Domain.Shipments;
public class Shipment
{
    private Shipment(long id, long orderId, ShipmentType shipmentType)
    {
        Id = id; 
        OrderId = orderId; 
        ShipmentType = shipmentType;
    }
    protected Shipment() { }
    public long Id { get; set; }
    public long OrderId { get; set; }
    public ShipmentType ShipmentType { get; set; }
    public bool DeliverToCustomer { get; set; }

    public static Shipment Build(long id, long orderId, ShipmentType shipmentType) =>
        new Shipment(id, orderId, shipmentType);
}
