using KShop.Core.Domain.Customers;
using KShop.Core.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kshop.Infra.Persistence.EntityFrameWork.Orders.EntityConfigurations;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders").HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.Property(c => c.Price);
        builder.Property(c => c.CustomerId);
        builder.HasOne(c => c.Customer);
    }
}
