using System.Collections.Generic;
using System.Linq;
using Microservicios.Kaure.Security.Models;
using Microservicios.Kaure.Security.Repositories;

namespace Microservicios.Kaure.Security.Services
{
    public class AccessService : IAccessService
    {
        private readonly IAccessRepository _accessRepository;

        public AccessService(IAccessRepository accessRepository)
        {
            _accessRepository = accessRepository;
        }

        public IEnumerable<Access> GetAll()
        {
            return _accessRepository.GetAll();
        }

        public bool Validate(string username, string password)
        {
            return _accessRepository
                .GetAll()
                .Any(x => x.Username == username && x.Password == password);
        }
    }
}
