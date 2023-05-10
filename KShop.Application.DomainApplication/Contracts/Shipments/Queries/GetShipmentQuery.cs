using MediatR;

namespace KShop.Application.DomainApplication.Contracts.Shipments.Queries;
public class GetShipmentQuery : IRequest<GetShipmentQueryResult>
{
    public long OrderId { get; set; }
}
