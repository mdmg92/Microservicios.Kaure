using Microservicios.Kaure.Cross.RabbitMQ.Events;

namespace Microservicios.Kaure.Notification.RabbitMQ.Events
{
    public class NotificationCreatedEvent : Event
    {
        public string SendDate { get; set; }
        public int AccountId { get; set; }

        public NotificationCreatedEvent(string sendDate, int accountId)
        {
            SendDate = sendDate;
            AccountId = accountId;
        }
    }
}
