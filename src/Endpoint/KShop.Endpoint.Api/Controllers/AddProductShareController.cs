using KShop.Application.DomainApplication.Contracts.Shares.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KShop.Endpoint.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AddProductShareController : ControllerBase
{
    private readonly IMediator mediator;

    public AddProductShareController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost(Name = "AddProductShare")]
    public async Task<long> AddProductShare(CreateShareCommand command, CancellationToken cancellationToken) =>
        await mediator.Send(command, cancellationToken);
}
