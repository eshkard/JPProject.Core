using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JPProject.Domain.Core.Events;
using JPProject.Domain.Core.ViewModels;

namespace JPProject.Domain.Core.Interfaces
{
    public interface IEventStoreRepository : IDisposable
    {
        Task Store(StoredEvent theEvent);
        Task<List<StoredEvent>> All(string username);
        Task<List<StoredEvent>> GetEvents(string username, PagingViewModel paging);
        Task<int> Count(string username, string search);
    }
}