using KShop.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Kshop.Infra.Persistence.EntityFrameWork.Customers.EntityConfigurations;
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.Property(c => c.FullName);
        builder.Property(c => c.Email);
        builder.Property(c => c.IsDeleted);
    }
}