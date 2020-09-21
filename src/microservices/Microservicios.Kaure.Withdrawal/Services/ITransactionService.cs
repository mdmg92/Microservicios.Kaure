using Microservicios.Kaure.Withdrawal.Models;

namespace Microservicios.Kaure.Withdrawal.Service
{
    public interface ITransactionService
    {
        Transaction Withdrawal(Transaction transaction);
        Transaction WithdrawalReverse(Transaction transaction);
    }
}
