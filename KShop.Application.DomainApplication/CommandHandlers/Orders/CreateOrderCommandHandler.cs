using IdGen;
using KShop.Application.DomainApplication.CommandHandlers.Orders.Mapping;
using KShop.Application.DomainApplication.Contracts.Orders.Commands;
using KShop.Core.Domain.Orders;
using KShop.Core.Domain.Orders.Exceptions;
using KShop.FrameWork.SharedFrameWork.AppSettingsConfiguration;
using MediatR;
using Microsoft.Extensions.Options;

namespace KShop.Application.DomainApplication.CommandHandlers.Orders;
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
{
    private readonly IIdGenerator<long> idGenerator;
    private readonly IOrderRepository orderRepository;
    private readonly IMediator mediator;
    private readonly IOptionsMonitor<MinPriceConfig> minPriceOptions;
    private readonly IOptionsMonitor<ValidShopTimeConfig> validShopTimeOptions;

    public CreateOrderCommandHandler(IIdGenerator<long> idGenerator, IOrderRepository orderRepository, IMediator mediator,
        IOptionsMonitor<MinPriceConfig> minPriceOptions, IOptionsMonitor<ValidShopTimeConfig> validShopTimeOptions)
    {
        this.idGenerator = idGenerator;
        this.orderRepository = orderRepository;
        this.mediator = mediator;
        this.minPriceOptions = minPriceOptions;
        this.validShopTimeOptions = validShopTimeOptions;
    }
    public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        PassLimitPrice(request);
        ValidTimeToShop();
        var id = idGenerator.CreateId();
        var orderItems = request.MapToOrderItems(id, idGenerator);
        var order = Order.Build(id, request.CustomerId, orderItems);
        await orderRepository.Create(order, cancellationToken);
        await mediator.Publish(order.ToCreateOrderEvent());
        return order.Id;
    }

    private void ValidTimeToShop()
    {
        if (DateTime.Now.Hour <= validShopTimeOptions.CurrentValue.FromHour || DateTime.Now.Hour >= validShopTimeOptions.CurrentValue.ToHour) throw new NotValidShopTimeException();
    }

    private void PassLimitPrice(CreateOrderCommand request)
    {
        if (request.Items.Sum(c => c.Price * c.Quantity) <= minPriceOptions.CurrentValue.MinPrice) throw new MinPriceLimitException();
    }
}
