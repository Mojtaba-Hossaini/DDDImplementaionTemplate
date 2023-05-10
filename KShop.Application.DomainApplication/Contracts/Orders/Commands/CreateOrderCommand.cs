using KShop.Core.Domain.Orders;
using MediatR;

namespace KShop.Application.DomainApplication.Contracts.Orders.Commands;
public class CreateOrderCommand : IRequest<long>
{
    public long CustomerId { get; set; }
    public long? DiscountId { get; set; }
    public List<OrderItem> Items { get; set; }
    public class OrderItem
    {
        public string ItemTitle { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public OrderItemType OrderItemType { get; set; }
    }
}

