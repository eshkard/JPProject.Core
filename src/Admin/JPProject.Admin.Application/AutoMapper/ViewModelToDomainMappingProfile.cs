using AutoMapper;
using IdentityServer4.Models;
using JPProject.Admin.Application.ViewModels;
using JPProject.Admin.Application.ViewModels.ApiResouceViewModels;
using JPProject.Admin.Application.ViewModels.ClientsViewModels;
using JPProject.Admin.Application.ViewModels.IdentityResourceViewModels;
using JPProject.Admin.Domain.Commands.ApiResource;
using JPProject.Admin.Domain.Commands.Clients;
using JPProject.Admin.Domain.Commands.IdentityResource;
using JPProject.Admin.Domain.Commands.PersistedGrant;

namespace JPProject.Admin.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            /*
             * Persisted grant
             */
            CreateMap<RemovePersistedGrantViewModel, RemovePersistedGrantCommand>().ConstructUsing(c => new RemovePersistedGrantCommand(c.Key));

            /*
             * Client commands
             */
            CreateMap<ClientViewModel, UpdateClientCommand>().ConstructUsing(c => new UpdateClientCommand(c, c.OldClientId));
            CreateMap<RemoveClientSecretViewModel, RemoveClientSecretCommand>().ConstructUsing(c => new RemoveClientSecretCommand(c.Id, c.ClientId));
            CreateMap<RemovePropertyViewModel, RemovePropertyCommand>().ConstructUsing(c => new RemovePropertyCommand(c.Id, c.ClientId));
            CreateMap<SaveClientSecretViewModel, SaveClientSecretCommand>().ConstructUsing(c => new SaveClientSecretCommand(c.ClientId, c.Description, c.Value, c.Type, c.Expiration, (int)c.Hash.GetValueOrDefault(HashType.Sha256)));
            CreateMap<SaveClientPropertyViewModel, SaveClientPropertyCommand>().ConstructUsing(c => new SaveClientPropertyCommand(c.ClientId, c.Key, c.Value));
            CreateMap<SaveClientClaimViewModel, SaveClientClaimCommand>().ConstructUsing(c => new SaveClientClaimCommand(c.ClientId, c.Type, c.Value));
            CreateMap<RemoveClientClaimViewModel, RemoveClientClaimCommand>().ConstructUsing(c => new RemoveClientClaimCommand(c.Id, c.ClientId));
            CreateMap<RemoveClientViewModel, RemoveClientCommand>().ConstructUsing(c => new RemoveClientCommand(c.ClientId));
            CreateMap<CopyClientViewModel, CopyClientCommand>().ConstructUsing(c => new CopyClientCommand(c.ClientId));
            CreateMap<SaveClientViewModel, SaveClientCommand>().ConstructUsing(c => new SaveClientCommand(c.ClientId, c.ClientName, c.ClientUri, c.LogoUri, c.Description, c.ClientType, c.LogoutUri));

            /*
             * Identity Resource commands
             */
            CreateMap<IdentityResource, RegisterIdentityResourceCommand>().ConstructUsing(c => new RegisterIdentityResourceCommand(c));
            CreateMap<RemoveIdentityResourceViewModel, RemoveIdentityResourceCommand>().ConstructUsing(c => new RemoveIdentityResourceCommand(c.Name));

            /*
             * Api Resource commands
             */
            CreateMap<ApiResource, RegisterApiResourceCommand>().ConstructUsing(c => new RegisterApiResourceCommand(c));
            CreateMap<UpdateApiResourceViewModel, UpdateApiResourceCommand>().ConstructUsing(c => new UpdateApiResourceCommand(c, c.OldApiResourceId));
            CreateMap<RemoveApiResourceViewModel, RemoveApiResourceCommand>().ConstructUsing(c => new RemoveApiResourceCommand(c.Name));

            CreateMap<SaveApiSecretViewModel, SaveApiSecretCommand>().ConstructUsing(c => new SaveApiSecretCommand(c.ResourceName, c.Description, c.Value, c.Type, c.Expiration, (int)c.Hash.GetValueOrDefault(HashType.Sha256)));
            CreateMap<RemoveApiSecretViewModel, RemoveApiSecretCommand>().ConstructUsing(c => new RemoveApiSecretCommand(c.Id, c.ResourceName));

            CreateMap<RemoveApiScopeViewModel, RemoveApiScopeCommand>().ConstructUsing(c => new RemoveApiScopeCommand(c.Id, c.ResourceName));
            CreateMap<SaveApiScopeViewModel, SaveApiScopeCommand>().ConstructUsing(c => new SaveApiScopeCommand(c.ResourceName, c.Name, c.Description, c.DisplayName, c.Emphasize, c.ShowInDiscoveryDocument, c.UserClaims));

        }
    }
}
