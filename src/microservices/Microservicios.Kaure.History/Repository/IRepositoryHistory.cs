using Microservicios.Kaure.History.Models;
using MongoDB.Driver;

namespace Microservicios.Kaure.History.Repository
{
    public interface IRepositoryHistory
    {
        IMongoCollection<HistoryTransaction> HistoryCredit { get; }
    }
}
