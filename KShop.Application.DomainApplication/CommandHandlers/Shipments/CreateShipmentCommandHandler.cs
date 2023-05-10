using IdGen;
using KShop.Application.DomainApplication.Contracts.Shipments.Commands;
using KShop.Core.Domain.Shipments;
using MediatR;

namespace KShop.Application.DomainApplication.CommandHandlers.Shipments;
public class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, long>
{
    private readonly IIdGenerator<long> idGenerator;
    private readonly IShipmentRepository shipmentRepository;

    public CreateShipmentCommandHandler(IIdGenerator<long> idGenerator, IShipmentRepository shipmentRepository)
    {
        this.idGenerator = idGenerator;
        this.shipmentRepository = shipmentRepository;
    }
    public async Task<long> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
    {
        var id = idGenerator.CreateId();
        var shipment = Shipment.Build(id, request.OrderId, request.ShipmentType);
        await shipmentRepository.Create(shipment, cancellationToken);
        return shipment.Id;
    }
}
