using System.Threading.Tasks;

namespace Microservicios.Kaure.Cross.Consul.Fabio
{
    public interface IFabioHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);
    }
}