using System.Collections.Generic;
using System.Linq;
using Microservicios.Kaure.Security.Models;
using Microservicios.Kaure.Security.Repositories.Data;

namespace Microservicios.Kaure.Security.Repositories
{
    public class AccessRepository : IAccessRepository
    {
        private readonly IContextDatabase _context;

        public AccessRepository(IContextDatabase context)
        {
            _context = context;
        }

        public IEnumerable<Access> GetAll()
        {
            return _context.Access.ToList();
        }
    }
}
