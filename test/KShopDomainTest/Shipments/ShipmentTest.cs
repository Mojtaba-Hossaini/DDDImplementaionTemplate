using KShopTestUtil.Orders;
using KShopTestUtil.Shipments;

namespace KShopDomainTest.Shipments;
public class ShipmentTest
{
    private ShipmentTestBuilder shipmentTestBuilder;
    public ShipmentTest()
    {
        shipmentTestBuilder = new ShipmentTestBuilder();
    }

    [Fact]
    public void create_properly()
    {
        var shipment = shipmentTestBuilder.Build();
        Assert.Equal(shipmentTestBuilder.Id, shipment.Id);
        Assert.Equal(shipmentTestBuilder.OrderId, shipment.OrderId);
        Assert.Equal(shipmentTestBuilder.ShipmentType, shipment.ShipmentType);
    }
}
