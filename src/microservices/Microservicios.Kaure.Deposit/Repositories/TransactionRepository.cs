using Microservicios.Kaure.Deposit.Models;
using Microservicios.Kaure.Deposit.Repositories.Data;

namespace Microservicios.Kaure.Deposit.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDepositContext _depositContext;

        public TransactionRepository(IDepositContext depositContext)
        {
            _depositContext = depositContext;
        }

        public Transaction Deposit(Transaction transaction)
        {
            _depositContext.Transaction.Add(transaction);
            _depositContext.SaveChanges();

            return transaction;
        }

        public Transaction DepositReverse(Transaction transaction)
        {
            _depositContext.Transaction.Add(transaction);
            _depositContext.SaveChanges();

            return transaction;
        }
    }
}
