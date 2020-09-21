using Microservicios.Kaure.Withdrawal.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Kaure.Withdrawal.Repositories.Data
{
    public interface IWithdrawalContext
    {
        DbSet<Transaction> Transaction { get; set; }
        int SaveChanges();
    }
}
