using Kshop.Infra.Persistence.EntityFrameWork.Contracts;
using KShop.Core.Domain.Shipments;
using Microsoft.EntityFrameworkCore;

namespace Kshop.Infra.Persistence.EntityFrameWork.Shipments;
public class ShipmentRepository : BaseRepository<Shipment, long>, IShipmentRepository
{
    public ShipmentRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task Create(Shipment shipment, CancellationToken cancellationToken)
    {
        DbSet.Add(shipment);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Shipment> GetById(long id, CancellationToken cancellationToken) => 
        await DbSet.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
}
