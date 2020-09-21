using Microservicios.Kaure.Withdrawal.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Kaure.Withdrawal.Repositories.Data
{
    public class WithdrawalContext : DbContext, IWithdrawalContext
    {
        public WithdrawalContext(DbContextOptions<WithdrawalContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transaction { get; set; }
    }
}
