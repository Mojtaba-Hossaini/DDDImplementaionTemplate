using MediatR;

namespace KShop.Application.DomainApplication.Contracts.Customers.Commands;
public class ModifyCustomerCommand : IRequest<int>
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
}
