using Microservicios.Kaure.Cross.RabbitMQ.Commands;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Kaure.Withdrawal.RabbitMQ.Commands
{
    public class WithdrawalCommand : Command
    {
        public int IdTransaction { get; protected set; }
        public decimal Amount { get; protected set; }
        public string Type { get; protected set; }
        public string CreationDate { get; protected set; }
        public int AccountId { get; protected set; }
    }
}
