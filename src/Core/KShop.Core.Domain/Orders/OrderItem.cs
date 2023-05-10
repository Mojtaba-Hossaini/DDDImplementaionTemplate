using KShop.Core.Domain.Orders.Exceptions;

namespace KShop.Core.Domain.Orders;
public class OrderItem
{
    private OrderItem(long id, long orderId, string itemTitle, long productId, int qty, decimal price, OrderItemType orderItemType)
    {
        if (qty <= 0) throw new ZeroQuantityException();
        Id = id;
        OrderId = orderId;
        ItemTitle = itemTitle;
        ProductId = productId;
        Quantity = qty;
        Price = price * Quantity;
        OrderItemType = orderItemType;
    }
    protected OrderItem() { }
    public long Id { get; set; }
    public long OrderId { get; set; }
    public string ItemTitle { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public OrderItemType OrderItemType { get; set; }
    public Order Order { get; set; }

    public static OrderItem Build(long id, long orderId, string itemTitle, long productId, int qty, decimal price, OrderItemType orderItemType) =>
        new OrderItem(id, orderId, itemTitle, productId, qty, price, orderItemType);
}
