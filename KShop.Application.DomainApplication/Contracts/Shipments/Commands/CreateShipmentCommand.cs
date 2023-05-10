using KShop.Core.Domain.Shipments;
using MediatR;

namespace KShop.Application.DomainApplication.Contracts.Shipments.Commands;
public class CreateShipmentCommand : IRequest<long>
{
    public long OrderId { get; set; }
    public ShipmentType ShipmentType { get; set; }
}
