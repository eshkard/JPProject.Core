using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JPProject.Admin.Application.ViewModels;
using JPProject.Domain.Core.ViewModels;

namespace JPProject.Admin.Application.Interfaces
{
    public interface IPersistedGrantAppService: IDisposable
    {
        Task<ListOfPersistedGrantViewModel> GetPersistedGrants(PagingViewModel paging);
        Task Remove(RemovePersistedGrantViewModel model);
    }
}