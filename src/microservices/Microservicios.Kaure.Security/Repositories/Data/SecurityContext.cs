using Microservicios.Kaure.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Kaure.Security.Repositories.Data
{
    public class SecurityContext : DbContext, IContextDatabase
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {
        }

        public DbSet<Access> Access { get; set; }
    }
}
