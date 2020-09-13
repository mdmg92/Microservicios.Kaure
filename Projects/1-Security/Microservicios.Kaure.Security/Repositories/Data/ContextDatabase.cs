using Microservicios.Kaure.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Kaure.Security.Repositories.Data
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Access> Access { get; set; }
    }
}
