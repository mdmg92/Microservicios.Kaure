using Microservicios.Kaure.Cross.RabbitMQ.Commands;

namespace Microservicios.Kaure.Deposit.RabbitMQ.Commands
{
    public class DepositCommand : Command
    {
        public int IdTransaction { get; protected set; }
        public decimal Amount { get; protected set; }
        public string Type { get; protected set; }
        public string CreationDate { get; protected set; }
        public int AccountId { get; protected set; }
    }
}
