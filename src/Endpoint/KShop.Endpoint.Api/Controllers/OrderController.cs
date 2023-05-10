using KShop.Application.DomainApplication.Contracts.Orders.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KShop.Endpoint.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator mediator;

    public OrderController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost(Name = "AddOrder")]
    public async Task<long> AddOrder(CreateOrderCommand command, CancellationToken cancellationToken) =>
        await mediator.Send(command, cancellationToken);
}
