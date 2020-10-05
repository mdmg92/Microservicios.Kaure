using Microservicios.Kaure.History.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Microservicios.Kaure.History.Repository
{
    public class RepositoryHistory : IRepositoryHistory
    {
        private readonly IMongoDatabase _database = null;

        public RepositoryHistory(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("Mongo"));
            if (client != null)
                _database = client.GetDatabase(configuration["mongo:database"]);
        }

        public IMongoCollection<HistoryTransaction> HistoryCredit => 
            _database.GetCollection<HistoryTransaction>("HistoryTransaction");
    }
}
