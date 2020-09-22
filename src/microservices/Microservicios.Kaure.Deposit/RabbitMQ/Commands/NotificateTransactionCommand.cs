using Microservicios.Kaure.Cross.RabbitMQ.Commands;

namespace Microservicios.Kaure.Deposit.RabbitMQ.Commands
{
    public class NotificateTransactionCommand : Command
    {
        public string SendDate { get; set; }
        public int AccountId { get; set; }
    }
}
