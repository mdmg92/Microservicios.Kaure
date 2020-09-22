using Microservicios.Kaure.Withdrawal.Models;

namespace Microservicios.Kaure.Withdrawal.Services
{
    public interface ITransactionService
    {
        Transaction Withdrawal(Transaction transaction);
        Transaction WithdrawalReverse(Transaction transaction);
    }
}
