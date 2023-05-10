using MediatR;

namespace KShop.Application.DomainApplication.Contracts.Shares.Commands;
public class CreateShareCommand : IRequest<long>
{
    public int ProductId { get; set; }
    public decimal ShareValue { get; set; }
}
