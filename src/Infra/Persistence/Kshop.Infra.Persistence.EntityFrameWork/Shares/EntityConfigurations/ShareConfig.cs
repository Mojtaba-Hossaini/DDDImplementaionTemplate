using KShop.Core.Domain.Shares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kshop.Infra.Persistence.EntityFrameWork.Shares.EntityConfigurations;

public class ShareConfig : IEntityTypeConfiguration<Share>
{
    public void Configure(EntityTypeBuilder<Share> builder)
    {
        builder.ToTable("Shares").HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.Property(c => c.ProductId);
        builder.Property(c => c.ShareValue);
    }
}
