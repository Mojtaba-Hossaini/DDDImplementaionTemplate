using KShopTestUtil.Customers;

namespace KShopDomainTest.Customers;
public class CustomerTest
{
    private readonly CustomerTestBuilder customerTestBuilder;
    public CustomerTest()
    {
        customerTestBuilder = new CustomerTestBuilder();
    }

    [Fact]
    public void create_properly()
    {
        var customer = customerTestBuilder.Build();

        Assert.Equal(customerTestBuilder.Id, customer.Id);
        Assert.Equal(customerTestBuilder.FullName, customer.FullName);
        Assert.Equal(customerTestBuilder.Email, customer.Email);
    }
}
