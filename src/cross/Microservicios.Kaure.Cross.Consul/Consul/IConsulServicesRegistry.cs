using System.Threading.Tasks;
using Consul;

namespace Microservicios.Kaure.Cross.Consul.Consul
{
    public interface IConsulServicesRegistry
    {
        Task<AgentService> GetAsync(string name);
    }
}