using KShop.Application.DomainApplication.Contracts.Discounts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KShop.Endpoint.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DiscountController : ControllerBase
{
    private readonly IMediator mediator;

    public DiscountController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost(Name = "AddDiscount")]
    public async Task<long> AddDiscount(CreateDiscountCommand command, CancellationToken cancellationToken) =>
        await mediator.Send(command, cancellationToken);
}
