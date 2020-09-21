using System.Collections.Generic;

namespace Microservicios.Kaure.Account.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<Models.Account> GetAll();
        bool Deposit(Models.Account account);
        bool Withdrawal(Models.Account account);
    }
}
