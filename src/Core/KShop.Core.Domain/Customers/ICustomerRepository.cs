namespace KShop.Core.Domain.Customers;
public interface ICustomerRepository
{
    Task Create(Customer customer, CancellationToken cancellationToken);
    Task Update(Customer customer);
    Task Delete(long id);
    Task<Customer> GetById(long id, CancellationToken cancellationToken);
}
