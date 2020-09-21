using Microservicios.Kaure.Deposit.Models;

namespace Microservicios.Kaure.Deposit.Services
{
    public interface ITransactionService
    {
        Transaction Deposit(Transaction transaction);
        Transaction DepositReverse(Transaction transaction);
    }
}
