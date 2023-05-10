using KShop.Core.Domain.Customers;

namespace KShopTestUtil.Customers;
public class CustomerTestBuilder
{
    public CustomerTestBuilder()
    {
        Id = 1;
        FullName = "Mojtaba";
        Email = "s.mojtaba1987@gmail.com";
    }
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool IsDeleted { get; set; }

    public Customer Build() =>
        Customer.Build(Id, FullName, Email);
}
