using Microservicios.Kaure.Withdrawal.Models;

namespace Microservicios.Kaure.Withdrawal.Repositories
{
    public interface ITransactionRepository
    {
        Transaction Withdrawal(Transaction transaction);
        Transaction WithdrawalReverse(Transaction transaction);
    }
}
