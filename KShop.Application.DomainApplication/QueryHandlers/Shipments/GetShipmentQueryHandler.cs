using KShop.Application.DomainApplication.Contracts.Shipments.Queries;
using KShop.Core.Domain.Shipments.Exceptions;
using KShop.Infra.Query.EntityFrameWork;
using KShop.Infra.Query.EntityFrameWork.Contracts;
using MediatR;

namespace KShop.Application.DomainApplication.QueryHandlers.Shipments;
public class GetShipmentQueryHandler : IRequestHandler<GetShipmentQuery, GetShipmentQueryResult>
{
    private readonly IShipmentQueryRepository shipmentQueryRepository;

    public GetShipmentQueryHandler(IShipmentQueryRepository shipmentQueryRepository)
    {
        this.shipmentQueryRepository = shipmentQueryRepository;
    }
    public async Task<GetShipmentQueryResult> Handle(GetShipmentQuery request, CancellationToken cancellationToken)
    {
        var shipment = await shipmentQueryRepository.GetShipmentById(request.OrderId, cancellationToken);
        if (shipment is null) throw new OrderNotFoundException();
        return new GetShipmentQueryResult
        {
            OrderId = shipment.OrderId,
            DeliverToCustomer = shipment.DeliverToCustomer,
            ShipmentType = Enum.GetName(typeof(ShipmentType), shipment.ShipmentType)
        };
    }
}
