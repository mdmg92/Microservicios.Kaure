using System.Collections.Generic;
using System.Threading.Tasks;
using Microservicios.Kaure.History.DTOs;
using Microservicios.Kaure.History.Models;

namespace Microservicios.Kaure.History.Services
{
    public interface IHistoryService
    {
        Task<IEnumerable<HistoryResponse>> GetAll();

        Task<bool> Add(HistoryTransaction historyTransaction);
    }
}
