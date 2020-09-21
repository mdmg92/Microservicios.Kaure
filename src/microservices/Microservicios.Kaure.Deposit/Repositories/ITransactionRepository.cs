using Microservicios.Kaure.Deposit.Models;

namespace Microservicios.Kaure.Deposit.Repositories
{
    public interface ITransactionRepository
    {
        Transaction Deposit(Transaction transaction);
        Transaction DepositReverse(Transaction transaction);
    }
}
