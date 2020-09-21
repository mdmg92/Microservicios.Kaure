using System.Collections.Generic;
using System.Linq;
using Microservicios.Kaure.Account.Repositories.Data;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Kaure.Account.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IAccountContext _accountContext;

        public AccountRepository(IAccountContext accountContext )
        {
            _accountContext = accountContext;
        }

        public bool Deposit(Models.Account account)
        {
            _accountContext.Account.Update(account);
            _accountContext.SaveChanges();

            return true;
        }

        public IEnumerable<Models.Account> GetAll() =>
            _accountContext.Account
                .Include(x => x.Customer)
                .AsNoTracking()
                .ToList();

        public bool Withdrawal(Models.Account account)
        {
            _accountContext.Account.Update(account);
            _accountContext.SaveChanges();

            return true;
        }
    }
}
