using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using JPProject.Domain.Core.Interfaces;

namespace JPProject.Admin.Domain.Interfaces
{
    public interface IClientPropertyRepository : IRepository<ClientProperty>
    {
        Task<IEnumerable<ClientProperty>> GetByClientId(string clientId);
    }
}