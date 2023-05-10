using KShop.Core.Domain.Shipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kshop.Infra.Persistence.EntityFrameWork.Shipments.EntityConfigurations;
public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.ToTable("Shipments").HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.Property(c => c.OrderId);
        builder.Property(c => c.ShipmentType);
        builder.Property(c => c.DeliverToCustomer);
    }
}
