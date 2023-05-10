using KShop.Core.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kshop.Infra.Persistence.EntityFrameWork.Orders.EntityConfigurations;
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems").HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.Property(c => c.Price);
        builder.Property(c => c.OrderId);
        builder.Property(c => c.ItemTitle);
        builder.Property(c => c.ProductId);
        builder.Property(c => c.Quantity);
        builder.Property(c => c.OrderItemType);
        builder.HasOne(c => c.Order).WithMany(c => c.Items).HasForeignKey(c => c.OrderId);
    }
}
