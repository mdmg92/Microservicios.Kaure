using Microservicios.Kaure.Withdrawal.Models;
using Microservicios.Kaure.Withdrawal.Repositories.Data;

namespace Microservicios.Kaure.Withdrawal.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IWithdrawalContext _withdrawalContext;

        public TransactionRepository(IWithdrawalContext withdrawalContext)
        {
            _withdrawalContext = withdrawalContext;
        }

        public Transaction Withdrawal(Transaction transaction)
        {
            _withdrawalContext.Transaction.Add(transaction);
            _withdrawalContext.SaveChanges();

            return transaction;
        }

        public Transaction WithdrawalReverse(Transaction transaction)
        {
            _withdrawalContext.Transaction.Add(transaction);
            _withdrawalContext.SaveChanges();

            return transaction;
        }
    }
}
