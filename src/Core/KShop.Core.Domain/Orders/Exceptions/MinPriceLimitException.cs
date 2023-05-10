namespace KShop.Core.Domain.Orders.Exceptions;
public class MinPriceLimitException : Exception
{
    public MinPriceLimitException() : base("Min price for order is 50000")
    {
        
    }
}
