using AutoMapper;
using IdentityServer4.Models;
using JPProject.Admin.Application.EventSourcedNormalizers;
using JPProject.Admin.Application.ViewModels;
using JPProject.Admin.Application.ViewModels.ApiResouceViewModels;
using JPProject.Admin.Application.ViewModels.ClientsViewModels;
using JPProject.Admin.Application.ViewModels.IdentityResourceViewModels;
using JPProject.Domain.Core.Events;
using System.Globalization;
using System.Security.Claims;
using JPProject.Domain.Core.ViewModels;

namespace JPProject.Admin.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<IdentityServer4.EntityFramework.Entities.ApiResource, ApiResourceListViewModel>();

            CreateMap<StoredEvent, EventHistoryData>().ConstructUsing(a => new EventHistoryData(a.Message, a.Id.ToString(), a.Details, a.Timestamp.ToString(CultureInfo.InvariantCulture), a.User, a.MessageType, a.RemoteIpAddress));
            CreateMap<Client, ClientListViewModel>(MemberList.Destination);
            CreateMap<IdentityServer4.EntityFramework.Entities.Secret, SecretViewModel>(MemberList.Destination);
            CreateMap<IdentityServer4.EntityFramework.Entities.ClientProperty, ClientPropertyViewModel>();
            CreateMap<IdentityServer4.EntityFramework.Entities.ClientClaim, ClaimViewModel>();
            CreateMap<IdentityServer4.EntityFramework.Entities.IdentityResource, IdentityResourceListView>(MemberList.Destination);
            CreateMap<IdentityServer4.EntityFramework.Entities.ApiScope, ScopeViewModel>();
            CreateMap<IdentityServer4.EntityFramework.Entities.UserClaim, ClaimViewModel>(MemberList.Destination);

            CreateMap<Claim, ClaimViewModel>(MemberList.Destination);

        }
    }
}
