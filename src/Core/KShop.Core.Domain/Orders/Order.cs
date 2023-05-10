using KShop.Core.Domain.Customers;
using KShop.Core.Domain.Discounts;
using KShop.Core.Domain.Orders.Exceptions;

namespace KShop.Core.Domain.Orders;
public class Order
{
    private Order(long id, long customerId, long? discountId, decimal price, List<OrderItem> items)
    {
        if (items == null || items.Count <= 0) throw new OrderItemsReqiredException();
        Id = id;
        CustomerId = customerId;
        DiscountId = discountId;
        Price = price;
        _items = items;
    }
    protected Order() { }
    public long Id { get; set; }
    public long? DiscountId { get; set; }
    public decimal Price { get; set; }
    public long CustomerId { get; set; }

    public Customer Customer { get; set; }
    public Discount? Discount { get; set; }

    private List<OrderItem> _items = new List<OrderItem>();

    public IReadOnlyCollection<OrderItem> Items { get { return _items.AsReadOnly(); } }

    public static Order Build(long id, long customerId, long? discountId, decimal price, List<OrderItem> items) => 
        new Order(id, customerId, discountId, price, items);
    
}
