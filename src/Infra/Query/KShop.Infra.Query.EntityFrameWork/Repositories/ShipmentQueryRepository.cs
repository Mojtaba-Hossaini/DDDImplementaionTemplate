using KShop.Infra.Query.EntityFrameWork.Contracts;
using KShop.Infra.Query.EntityFrameWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace KShop.Infra.Query.EntityFrameWork.Repositories;
public class ShipmentQueryRepository : IShipmentQueryRepository
{
    private readonly KShopQueryDbContext dbContext;

    public ShipmentQueryRepository(KShopQueryDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Shipment> GetShipmentById(long orderId, CancellationToken cancellationToken) => 
        await dbContext.Shipments.FirstOrDefaultAsync(c => c.OrderId == orderId, cancellationToken);
}
