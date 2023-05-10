using IdGen;
using KShop.Application.DomainApplication.Contracts.Discounts.Commands;
using KShop.Core.Domain.Discounts;
using MediatR;

namespace KShop.Application.DomainApplication.CommandHandlers.Discounts;

public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, long>
{
    private readonly IDiscountRepository discountRepository;
    private readonly IIdGenerator<long> idGenerator;

    public CreateDiscountCommandHandler(IDiscountRepository discountRepository, IIdGenerator<long> idGenerator)
    {
        this.discountRepository = discountRepository;
        this.idGenerator = idGenerator;
    }
    public async Task<long> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var id = idGenerator.CreateId();
        var discount = Discount.Build(id, request.Title, request.Value, request.DiscountValueType);
        await discountRepository.Create(discount, cancellationToken);
        return discount.Id;
    }
}
