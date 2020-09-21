using Microservicios.Kaure.Account.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Kaure.Account.Repositories.Data
{
    public interface IAccountContext
    {
        DbSet<Models.Account> Account { get; set; }
        DbSet<Customer> Customer { get; set; }
        int SaveChanges();
    }
}
