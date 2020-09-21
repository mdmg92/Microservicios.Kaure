using System.Collections.Generic;
using Microservicios.Kaure.Security.Models;

namespace Microservicios.Kaure.Security.Services
{
    public interface IAccessService
    {
        IEnumerable<Access> GetAll();

        bool Validate(string username, string password);
    }
}
