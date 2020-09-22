using System.Threading.Tasks;
using Microservicios.Kaure.Deposit.DTOs;
using Microservicios.Kaure.Deposit.Models;

namespace Microservicios.Kaure.Deposit.Services
{
    public interface IAccountService
    {
        Task<bool> DepositAccount(AccountRequest request);
        bool DepositReverse(Transaction request);
        bool Execute(Transaction request);
    }
}
