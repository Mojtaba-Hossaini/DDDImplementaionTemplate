using Kshop.Infra.Persistence.EntityFrameWork.Contracts;
using KShop.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Kshop.Infra.Persistence.EntityFrameWork.Customers;
public class CustomerRepository : BaseRepository<Customer, long>, ICustomerRepository
{
    private readonly KShopDbContext dbContext;

    public CustomerRepository(KShopDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task Create(Customer customer, CancellationToken cancellationToken)
    {
        DbSet.Add(customer);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public Task Delete(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<Customer> GetById(long id, CancellationToken cancellationToken) => await DbSet.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public Task Update(Customer customer)
    {
        throw new NotImplementedException();
    }
}
