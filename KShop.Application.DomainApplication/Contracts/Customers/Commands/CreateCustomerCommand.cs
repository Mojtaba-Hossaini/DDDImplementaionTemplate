using MediatR;

namespace KShop.Application.DomainApplication.Contracts.Customers.Commands;
public class CreateCustomerCommand : IRequest<long>
{
    public string FullName { get; set; }
    public string Email { get; set; }
}
