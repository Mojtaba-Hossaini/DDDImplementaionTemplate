using KShop.Application.DomainApplication.Contracts.Shipments.Commands;
using KShop.Core.Domain.Orders;
using KShop.Core.Domain.Orders.Events;
using KShop.Core.Domain.Shipments;
using MediatR;

namespace KShop.EndPoint.Subscriber.EventHandlers.Orders;
public class CreateOrderEventHandler : INotificationHandler<CreateOrderEvent>
{
    private readonly IMediator mediator;

    public CreateOrderEventHandler(IMediator mediator)
    {
        this.mediator = mediator;
    }
    public async Task Handle(CreateOrderEvent notification, CancellationToken cancellationToken)
    {
        var shipmentType = notification.Items.Any(c => c.OrderItemType == OrderItemType.Breakable) ? ShipmentType.FastExpress : ShipmentType.Normal;
        await mediator.Send(new CreateShipmentCommand
        {
            OrderId = notification.OrderId,
            ShipmentType = shipmentType
        }, cancellationToken);
    }
}
