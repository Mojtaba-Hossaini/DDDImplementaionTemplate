using MediatR;

namespace KShop.Core.Domain.Orders.Events;
public class CreateOrderEvent : INotification
{
    public long OrderId { get; set; }
    public long CustomerId { get; set; }
    public List<OrderItem> Items { get; set; }
    public decimal Price { get; set; }
    public class OrderItem
    {
        public long OrderItemId { get; set; }
        public string ItemTitle { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public OrderItemType OrderItemType { get; set; }
    }
}
