using System.Collections.Generic;

namespace Microservicios.Kaure.Account.Services
{
    public interface IAccountService
    {
        IEnumerable<Models.Account> GetAll();
        bool Deposit(Models.Account account);
        bool Withdrawal(Models.Account account);
    }
}
