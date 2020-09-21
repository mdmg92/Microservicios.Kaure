using System.Collections.Generic;
using Microservicios.Kaure.Account.Repositories;

namespace Microservicios.Kaure.Account.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool Deposit(Models.Account account) => _accountRepository.Deposit(account);

        public IEnumerable<Models.Account> GetAll() => _accountRepository.GetAll();

        public bool Withdrawal(Models.Account account) => _accountRepository.Withdrawal(account);
    }
}
