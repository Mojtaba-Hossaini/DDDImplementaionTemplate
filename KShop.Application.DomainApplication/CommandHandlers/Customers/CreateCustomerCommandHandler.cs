using IdGen;
using KShop.Application.DomainApplication.Contracts.Customers.Commands;
using KShop.Core.Domain.Customers;
using MediatR;

namespace KShop.Application.DomainApplication.CommandHandlers.Customers;
public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, long>
{
    private readonly IIdGenerator<long> idGenerator;
    private readonly ICustomerRepository customerRepository;

    public CreateCustomerCommandHandler(IIdGenerator<long> idGenerator, ICustomerRepository customerRepository)
    {
        this.idGenerator = idGenerator;
        this.customerRepository = customerRepository;
    }
    public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var id = idGenerator.CreateId();
        var customer = Customer.Build(id, request.FullName, request.Email);
        await customerRepository.Create(customer, cancellationToken);
        return customer.Id;
    }
}
