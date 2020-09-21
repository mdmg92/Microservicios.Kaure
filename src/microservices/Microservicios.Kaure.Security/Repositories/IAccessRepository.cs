using System.Collections.Generic;
using Microservicios.Kaure.Security.Models;

namespace Microservicios.Kaure.Security.Repositories
{
    public interface IAccessRepository
    {
        IEnumerable<Access> GetAll();
    }
}
