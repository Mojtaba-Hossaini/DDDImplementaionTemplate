namespace KShop.Core.Domain.Orders.Exceptions;
public class ZeroQuantityException : Exception
{
    public ZeroQuantityException() : base("Quantity for item must greater than zero")
    {
        
    }
}
