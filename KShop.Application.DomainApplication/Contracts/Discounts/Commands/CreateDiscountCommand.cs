using KShop.Core.Domain.Discounts;
using MediatR;

namespace KShop.Application.DomainApplication.Contracts.Discounts.Commands;

public class CreateDiscountCommand : IRequest<long>
{
    public string Title { get; set; }
    public int Value { get; set; }
    public DiscountValueType DiscountValueType { get; set; }
}
