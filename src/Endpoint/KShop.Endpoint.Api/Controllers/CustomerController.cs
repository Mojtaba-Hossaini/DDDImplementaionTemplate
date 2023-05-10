using KShop.Application.DomainApplication.Contracts.Customers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KShop.Endpoint.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator mediator;

    public CustomerController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost(Name = "AddCustomer")]
    public async Task<long> AddCustomer(CreateCustomerCommand command, CancellationToken cancellationToken) => 
        await mediator.Send(command, cancellationToken);
}
