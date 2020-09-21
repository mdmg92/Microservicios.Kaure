using Microservicios.Kaure.Deposit.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Kaure.Deposit.Repositories.Data
{
    public interface IDepositContext
    {
        DbSet<Transaction> Transaction { get; set; }
        int SaveChanges();
    }
}
