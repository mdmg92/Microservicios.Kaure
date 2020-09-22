using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microservicios.Kaure.Cross.RabbitMQ.Bus;
using Microservicios.Kaure.Withdrawal.RabbitMQ.Commands;
using Microservicios.Kaure.Withdrawal.RabbitMQ.Events;

namespace Microservicios.Kaure.Withdrawal.RabbitMQ.Handlers
{
    public class WithdrawalCommandHandler : IRequestHandler<WithdrawalCreateCommand, bool>
    {
        private readonly IEventBus _bus;

        public WithdrawalCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(WithdrawalCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish<WithdrawalCreatedEvent>(new WithdrawalCreatedEvent(
                request.IdTransaction,
                request.Amount,
                request.Type,
                request.CreationDate,
                request.AccountId));

            return Task.FromResult(true);
        }
    }
}
