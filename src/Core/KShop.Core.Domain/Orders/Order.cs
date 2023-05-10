using KShop.Core.Domain.Customers;
using KShop.Core.Domain.Orders.Exceptions;

namespace KShop.Core.Domain.Orders;
public class Order
{
    private Order(long id, long customerId, List<OrderItem> items)
    {
        if (items == null || items.Count <= 0) throw new OrderItemsReqiredException();
        Id = id;
        CustomerId = customerId;
        _items = items;
    }
    protected Order() { }
    public long Id { get; set; }
    public decimal Price { get; set; }
    public long CustomerId { get; set; }

    public Customer Customer { get; set; }

    private List<OrderItem> _items = new List<OrderItem>();

    public IReadOnlyCollection<OrderItem> Items { get { return _items.AsReadOnly(); } }

    public static Order Build(long id, long customerId, List<OrderItem> items) => new Order(id, customerId, items);
    
}
