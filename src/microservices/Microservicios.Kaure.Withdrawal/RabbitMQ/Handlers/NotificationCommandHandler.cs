using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microservicios.Kaure.Cross.RabbitMQ.Bus;
using Microservicios.Kaure.Withdrawal.RabbitMQ.Commands;
using Microservicios.Kaure.Withdrawal.RabbitMQ.Events;

namespace Microservicios.Kaure.Withdrawal.RabbitMQ.Handlers
{
    public class NotificationCommandHandler : IRequestHandler<NotificateTransactionCommand, bool>
    {
        private readonly IEventBus _bus;

        public NotificationCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(NotificateTransactionCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new NotificationCreatedEvent(
                request.SendDate,
                request.AccountId));

            return Task.FromResult(true);
        }
    }
}