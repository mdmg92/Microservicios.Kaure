using System.Threading.Tasks;
using Microservicios.Kaure.Withdrawal.DTOs;
using Microservicios.Kaure.Withdrawal.Models;

namespace Microservicios.Kaure.Withdrawal.Services
{
    public interface IAccountService
    {
        Task<bool> WithdrawalAccount(AccountRequest request);
        bool WithdrawalReverse(Transaction request);
        bool Execute(Transaction request);
    }
}
