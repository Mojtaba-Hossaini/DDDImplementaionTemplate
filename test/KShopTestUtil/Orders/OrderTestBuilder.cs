using KShop.Core.Domain.Orders;

namespace KShopTestUtil.Orders;
public class OrderTestBuilder
{
    public OrderTestBuilder()
    {
        Id = 1;
        CustomerId = 1;
        OrderItems = new List<OrderItem>
        {
            new OrderItem
            {
                Id = 1,
                ItemTitle = "Test",
                OrderId = 1,
                OrderItemType = OrderItemType.Breakable,
                Price = 85000,
                ProductId = 1,
                Quantity = 1
            }
        };
    }
    public long Id { get; set; }
    public decimal Price { get; set; }
    public long CustomerId { get; set; }


    public List<OrderItem> OrderItems { get; set; }
    public List<KShop.Core.Domain.Orders.OrderItem> BuildOrderItem()
    {
        var orderItemsLst = new List<KShop.Core.Domain.Orders.OrderItem>();
        foreach (var item in OrderItems)
        {
            orderItemsLst.Add(KShop.Core.Domain.Orders.OrderItem.Build(item.Id, item.OrderId, item.ItemTitle, item.ProductId, item.Quantity, item.Price, item.OrderItemType));
        }
        return orderItemsLst;
    }


    public Order Build()
        => Order.Build(Id, CustomerId, null, Price, BuildOrderItem());
}

public class OrderItem
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public string ItemTitle { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public OrderItemType OrderItemType { get; set; }
}
