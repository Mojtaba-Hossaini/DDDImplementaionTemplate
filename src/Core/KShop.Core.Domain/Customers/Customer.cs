namespace KShop.Core.Domain.Customers;
public class Customer
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool IsDeleted { get; set; }

    private Customer(long id, string fullName, string email)
    {
        Id = id;
        FullName = fullName;
        Email = email;
    }
    protected Customer() { }

    public static Customer Build(long id, string fullName, string email) => new Customer(id, fullName, email);

    public void Modify(string name, string email)
    {
        //event must be raised.
        FullName = name;
        Email = email;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}
