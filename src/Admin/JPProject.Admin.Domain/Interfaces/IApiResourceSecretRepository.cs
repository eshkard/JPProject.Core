using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using JPProject.Domain.Core.Interfaces;

namespace JPProject.Admin.Domain.Interfaces
{
    public interface IApiSecretRepository : IRepository<ApiSecret>
    {
        Task<IEnumerable<ApiSecret>> GetByApiName(string clientId);
    }
}