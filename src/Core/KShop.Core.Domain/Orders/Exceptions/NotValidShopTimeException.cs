namespace KShop.Core.Domain.Orders.Exceptions;
public class NotValidShopTimeException : Exception
{
    public NotValidShopTimeException() : base("Valid time for shoppin is between 08 to 19")
    {
        
    }
}
