using IdentityServer4.EntityFramework.Entities;
using System.Threading.Tasks;
using JPProject.Domain.Core.Interfaces;

namespace JPProject.Admin.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetClient(string clientId);
        Task UpdateWithChildrens(Client client);
        Task<Client> GetByClientId(string requestClientId);

        Task<Client> GetClientDefaultDetails(string clientId);
    }
}
