using System.Threading.Tasks;

namespace Microservicios.Kaure.Cross.Consul.Consul
{
    public interface IConsulHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);
    }
}

