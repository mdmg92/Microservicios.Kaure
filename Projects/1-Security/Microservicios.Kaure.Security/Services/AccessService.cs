using System.Collections.Generic;
using System.Linq;
using Microservicios.Kaure.Security.Models;
using Microservicios.Kaure.Security.Repositories;

namespace Microservicios.Kaure.Security.Services
{
    public class AccessService : IAccessService
    {
        private readonly IAccessRepository _repository;

        public AccessService(IAccessRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Access> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Validate(string username, string password)
        {
            return _repository
                .GetAll()
                .Any(x => x.Username == username && x.Password == password);
        }
    }
}
