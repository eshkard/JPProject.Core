using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using JPProject.Domain.Core.Interfaces;

namespace JPProject.Admin.Domain.Interfaces
{
    public interface IApiResourceRepository : IRepository<ApiResource>
    {
        Task<List<ApiResource>> GetResources();
        Task<ApiResource> GetByName(string name);
        Task UpdateWithChildrens(ApiResource irs);
        Task<ApiResource> GetResource(string resourceName);
    }
}