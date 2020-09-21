using Microservicios.Kaure.Deposit.Models;
using Microservicios.Kaure.Deposit.Repositories;

namespace Microservicios.Kaure.Deposit.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Transaction Deposit(Transaction transaction) => _transactionRepository.Deposit(transaction);

        public Transaction DepositReverse(Transaction transaction) => _transactionRepository.DepositReverse(transaction);
    }
}
