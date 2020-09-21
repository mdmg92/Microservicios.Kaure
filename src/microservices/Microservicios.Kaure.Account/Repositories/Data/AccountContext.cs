using Microservicios.Kaure.Account.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Kaure.Account.Repositories.Data
{
    public class AccountContext : DbContext, IAccountContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        public DbSet<Models.Account> Account { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbContext Instance => this;
    }
}
