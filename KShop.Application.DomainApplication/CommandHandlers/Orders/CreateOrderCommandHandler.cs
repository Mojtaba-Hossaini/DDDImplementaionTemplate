using IdGen;
using KShop.Application.DomainApplication.CommandHandlers.Orders.Mapping;
using KShop.Application.DomainApplication.Contracts.Orders.Commands;
using KShop.Core.Domain.Discounts;
using KShop.Core.Domain.Orders;
using KShop.Core.Domain.Orders.Exceptions;
using KShop.Core.Domain.Shares;
using KShop.FrameWork.SharedFrameWork.AppSettingsConfiguration;
using MediatR;
using Microsoft.Extensions.Options;

namespace KShop.Application.DomainApplication.CommandHandlers.Orders;
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
{
    private readonly IIdGenerator<long> idGenerator;
    private readonly IOrderRepository orderRepository;
    private readonly IDiscountRepository discountRepository;
    private readonly IShareRepository shareRepository;
    private readonly IMediator mediator;
    private readonly IOptionsMonitor<MinPriceConfig> minPriceOptions;
    private readonly IOptionsMonitor<ValidShopTimeConfig> validShopTimeOptions;

    public CreateOrderCommandHandler(IIdGenerator<long> idGenerator, 
        IOrderRepository orderRepository, IDiscountRepository discountRepository,
        IShareRepository shareRepository,
        IMediator mediator,
        IOptionsMonitor<MinPriceConfig> minPriceOptions, IOptionsMonitor<ValidShopTimeConfig> validShopTimeOptions)
    {
        this.idGenerator = idGenerator;
        this.orderRepository = orderRepository;
        this.discountRepository = discountRepository;
        this.shareRepository = shareRepository;
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
        var orderPrice = await CalculatePrice(request, orderItems, cancellationToken);
        var order = Order.Build(id, request.CustomerId, request.DiscountId, orderPrice, orderItems);
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
    private async Task<decimal> CalculatePrice(CreateOrderCommand request, List<OrderItem> orderItems,
        CancellationToken cancellationToken)
    {
        await GetShare(orderItems, cancellationToken);
        var orderItemsPrice = orderItems.Sum(c => c.Price * c.Quantity);
        var finalPrice = orderItemsPrice;
        var discount = await discountRepository.GetById(request.DiscountId ?? 0, cancellationToken);
        if (discount != null)
        {
            if (discount.DiscountValueType == DiscountValueType.Value)
                finalPrice = finalPrice - discount.Value;
            else
                finalPrice = finalPrice - ((finalPrice * discount.Value) / 100);
        }
        
        return finalPrice;
    }

    private async Task GetShare(List<OrderItem> orderItems, CancellationToken cancellationToken)
    {
        foreach (var item in orderItems)
        {
            var share = await shareRepository.GetByProductId(item.ProductId, cancellationToken);
            if (share != null)
                item.Price += share.ShareValue;
        }
    }
}
