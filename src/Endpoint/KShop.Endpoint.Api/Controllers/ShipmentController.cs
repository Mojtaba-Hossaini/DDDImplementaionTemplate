using KShop.Application.DomainApplication.Contracts.Shipments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KShop.Endpoint.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ShipmentController : ControllerBase
{
    private readonly IMediator mediator;

    public ShipmentController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpGet(Name = "GetShipment/{orderId}")]
    public async Task<GetShipmentQueryResult> GetShipment(long orderId, CancellationToken cancellationToken) =>
        await mediator.Send(new GetShipmentQuery { OrderId = orderId }, cancellationToken);
}
