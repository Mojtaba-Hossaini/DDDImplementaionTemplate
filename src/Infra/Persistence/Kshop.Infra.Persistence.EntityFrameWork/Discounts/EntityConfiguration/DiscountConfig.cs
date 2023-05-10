using KShop.Core.Domain.Discounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kshop.Infra.Persistence.EntityFrameWork.Discounts.EntityConfiguration;
public class DiscountConfig : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable("Discounts").HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.Property(c => c.Title);
        builder.Property(c => c.Value);
        builder.Property(c => c.DiscountValueType);
    }
}
