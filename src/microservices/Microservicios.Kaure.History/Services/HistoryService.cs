using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservicios.Kaure.History.DTOs;
using Microservicios.Kaure.History.Models;
using Microservicios.Kaure.History.Repository;
using MongoDB.Driver;

namespace Microservicios.Kaure.History.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IRepositoryHistory _repositoryHistory;

        public HistoryService(IRepositoryHistory repositoryHistory)
        {
            _repositoryHistory = repositoryHistory;
        }

        public async Task<bool> Add(HistoryTransaction historyTransaction)
        {
            await _repositoryHistory.HistoryCredit.InsertOneAsync(historyTransaction);

            return true;
        }

        public async Task<IEnumerable<HistoryResponse>> GetAll()
        {
            var data = await _repositoryHistory.HistoryCredit
                .Find(_ => true)
                .ToListAsync();

            return data.Select(item => new HistoryResponse()
                {
                    AccountId = item.AccountId,
                    Amount = item.Amount,
                    CreationDate = item.CreationDate,
                    IdTransaction = item.IdTransaction,
                    Type = item.Type
                })
                .ToList();
        }
    }
}
