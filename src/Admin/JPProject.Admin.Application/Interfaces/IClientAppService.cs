using IdentityServer4.Models;
using JPProject.Admin.Application.ViewModels;
using JPProject.Admin.Application.ViewModels.ClientsViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JPProject.Domain.Core.ViewModels;

namespace JPProject.Admin.Application.Interfaces
{
    public interface IClientAppService : IDisposable
    {
        Task<bool> SaveProperty(SaveClientPropertyViewModel model);
        Task<bool> SaveSecret(SaveClientSecretViewModel model);
        Task<bool> SaveClaim(SaveClientClaimViewModel model);
        Task<bool> Save(SaveClientViewModel client);

        Task<bool> RemoveSecret(RemoveClientSecretViewModel model);
        Task<bool> RemoveClaim(RemoveClientClaimViewModel model);
        Task<bool> RemoveProperty(RemovePropertyViewModel model);
        Task<bool> Remove(RemoveClientViewModel client);

        Task<IEnumerable<ClientListViewModel>> GetClients();
        Task<Client> GetClientDetails(string clientId);
        Task<bool> Update(string id, Client client);
        Task<IEnumerable<SecretViewModel>> GetSecrets(string clientId);
        Task<IEnumerable<ClientPropertyViewModel>> GetProperties(string clientId);
        Task<IEnumerable<ClaimViewModel>> GetClaims(string clientId);
        Task<bool> Copy(CopyClientViewModel client);
        Task<Client> GetClientDefaultDetails(string clientId);
    }
}