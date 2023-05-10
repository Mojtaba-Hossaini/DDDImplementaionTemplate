using KShop.Core.Domain.Orders.Exceptions;
using KShopTestUtil.Orders;

namespace KShopDomainTest.Orders;
public class OrderTest
{
    private OrderTestBuilder orderTestBuilder;
    public OrderTest()
    {
        orderTestBuilder = new OrderTestBuilder();
    }

    [Fact]
    public void create_properly()
    {
        var order = orderTestBuilder.Build();
        Assert.Equal(orderTestBuilder.Id, order.Id);
        Assert.Equal(orderTestBuilder.Price, order.Price);
    }

    [Fact]
    public void must_throw_OrderItemsReqiredException()
    {
        orderTestBuilder.OrderItems.Clear();
        //var order = orderTestBuilder.Build();
        Assert.Throws<OrderItemsReqiredException>(orderTestBuilder.Build);
    
    }
}
