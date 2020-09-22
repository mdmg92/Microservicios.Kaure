using System.Threading.Tasks;
using Microservicios.Kaure.Cross.RabbitMQ.Bus;
using Microservicios.Kaure.History.Models;
using Microservicios.Kaure.History.RabbitMQ.Events;
using Microservicios.Kaure.History.Services;

namespace Microservicios.Kaure.History.RabbitMQ.Handlers
{
    public class WithdrawalEventHandler : IEventHandler<WithdrawalCreatedEvent>
    {
        private readonly IHistoryService _service;

        public WithdrawalEventHandler(IHistoryService service)
        {
            _service = service;
        }

        public Task Handle(WithdrawalCreatedEvent @event)
        {
            _service.Add(new HistoryTransaction
            {
                Amount = @event.Amount,
                Type = @event.Type,
                AccountId = @event.AccountId,
                CreationDate = @event.CreationDate,
                IdTransaction = @event.IdTransaction
            });

            return Task.CompletedTask;
        }
    }
}
