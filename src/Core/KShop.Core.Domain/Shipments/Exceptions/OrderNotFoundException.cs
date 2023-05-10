namespace KShop.Core.Domain.Shipments.Exceptions;

public class OrderNotFoundException : Exception
{
    public OrderNotFoundException() : base("order or shipment not found")
    {
        
    }
}
