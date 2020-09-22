using System.Threading.Tasks;
using Microservicios.Kaure.Cross.RabbitMQ.Bus;
using Microservicios.Kaure.Notification.Models;
using Microservicios.Kaure.Notification.RabbitMQ.Events;
using Microservicios.Kaure.Notification.Repositories;

namespace Microservicios.Kaure.Notification.RabbitMQ.Handlers
{
    public class NotificationEventHandler: IEventHandler<NotificationCreatedEvent>
    {
        private readonly IMailRepository _repository;

        public NotificationEventHandler(IMailRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(NotificationCreatedEvent @event)
        {
            _repository.Add(new SendMail
            {
                SendDate = @event.SendDate,
                AccountId = @event.AccountId
            });

            return Task.CompletedTask;
        }
    }
}
