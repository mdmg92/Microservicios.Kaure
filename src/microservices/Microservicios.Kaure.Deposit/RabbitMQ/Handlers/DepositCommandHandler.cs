using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microservicios.Kaure.Cross.RabbitMQ.Bus;
using Microservicios.Kaure.Deposit.RabbitMQ.Commands;
using Microservicios.Kaure.Deposit.RabbitMQ.Events;

namespace Microservicios.Kaure.Deposit.RabbitMQ.Handlers
{
    public class DepositCommandHandler : IRequestHandler<DepositCreateCommand, bool>
    {
        private readonly IEventBus _bus;

        public DepositCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(DepositCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new DepositCreatedEvent(
                request.IdTransaction,
                request.Amount,
                request.Type,
                request.CreationDate,
                request.AccountId));

            return Task.FromResult(true);
        }
    }
}
