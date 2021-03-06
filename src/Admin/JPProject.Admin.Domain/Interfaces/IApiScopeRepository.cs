using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using JPProject.Domain.Core.Interfaces;

namespace JPProject.Admin.Domain.Interfaces
{
    public interface IApiScopeRepository : IRepository<ApiScope>
    {
        Task<List<ApiScope>> SearchScopes(string search);
        Task<List<ApiScope>> GetScopesByResource(string search);
    }
}