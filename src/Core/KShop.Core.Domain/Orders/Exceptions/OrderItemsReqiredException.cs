namespace KShop.Core.Domain.Orders.Exceptions;
public class OrderItemsReqiredException : Exception
{
    public OrderItemsReqiredException() : base("Order Items is Reqired. you must add some item")
    {
        
    }
}
