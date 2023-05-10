using IdGen;
using KShop.Application.DomainApplication.Contracts.Orders.Commands;
using KShop.Core.Domain.Orders;
using KShop.Core.Domain.Orders.Events;

namespace KShop.Application.DomainApplication.CommandHandlers.Orders.Mapping;
public static class OrdersMapper
{
    public static List<OrderItem> MapToOrderItems(this CreateOrderCommand request, long orderId, IIdGenerator<long> idGenerator)
    {
        var orderItems = new List<OrderItem>();
        foreach (var item in request.Items)
        {
            var orderItemId = idGenerator.CreateId();
            orderItems.Add(OrderItem.Build(orderItemId, orderId, item.ItemTitle, item.ProductId, item.Quantity, item.Price, item.OrderItemType));
        }
        return orderItems;
    }

    public static CreateOrderEvent ToCreateOrderEvent(this Order order) => new CreateOrderEvent
    {
        CustomerId = order.CustomerId,
        OrderId = order.Id,
        Price = order.Price,
        Items = order.Items.Select(c => new CreateOrderEvent.OrderItem
        {
            Price = c.Price,
            ItemTitle = c.ItemTitle,
            OrderItemId = c.Id,
            OrderItemType = c.OrderItemType,
            ProductId = c.ProductId,
            Quantity = c.Quantity
        }).ToList()
    };
}
