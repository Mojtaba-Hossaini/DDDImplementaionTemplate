using IdGen;
using KShop.Application.DomainApplication.Contracts.Shares.Commands;
using KShop.Core.Domain.Shares;
using MediatR;

namespace KShop.Application.DomainApplication.CommandHandlers.Shares;

public class CreateShareCommandHandler : IRequestHandler<CreateShareCommand, long>
{
    private readonly IShareRepository shareRepository;
    private readonly IIdGenerator<long> idGenerator;

    public CreateShareCommandHandler(IShareRepository shareRepository, IIdGenerator<long> idGenerator)
    {
        this.shareRepository = shareRepository;
        this.idGenerator = idGenerator;
    }
    public async Task<long> Handle(CreateShareCommand request, CancellationToken cancellationToken)
    {
        var id = idGenerator.CreateId();
        var share = Share.Build(id, request.ProductId, request.ShareValue);
        await shareRepository.Create(share, cancellationToken);
        return share.Id;
    }
}
