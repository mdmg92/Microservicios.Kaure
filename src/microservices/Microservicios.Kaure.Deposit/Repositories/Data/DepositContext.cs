using Microservicios.Kaure.Deposit.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Kaure.Deposit.Repositories.Data
{
    public class DepositContext : DbContext, IDepositContext
    {
        public DepositContext(DbContextOptions<DepositContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transaction { get; set; }
    }
}
