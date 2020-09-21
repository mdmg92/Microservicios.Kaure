using Microservicios.Kaure.Withdrawal.Models;
using Microservicios.Kaure.Withdrawal.Repositories;

namespace Microservicios.Kaure.Withdrawal.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Transaction Withdrawal(Transaction transaction) => 
            _transactionRepository.Withdrawal(transaction);

        public Transaction WithdrawalReverse(Transaction transaction) =>
            _transactionRepository.WithdrawalReverse(transaction);
    }
}
