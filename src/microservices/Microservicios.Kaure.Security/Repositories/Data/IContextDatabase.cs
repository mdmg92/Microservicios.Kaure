using Microservicios.Kaure.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Kaure.Security.Repositories.Data
{
    public interface IContextDatabase
    {
        DbSet<Access> Access { get; set; }
    }
}
