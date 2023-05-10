namespace KShop.Infra.Query.EntityFrameWork.Entities;
public class Shipment
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public ShipmentType ShipmentType { get; set; }
    public bool DeliverToCustomer { get; set; }
}
