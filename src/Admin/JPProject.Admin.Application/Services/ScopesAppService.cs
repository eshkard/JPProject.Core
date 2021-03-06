using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JPProject.Admin.Application.Interfaces;
using JPProject.Domain.Core.Bus;
using JPProject.Admin.Domain.Interfaces;
using JPProject.Domain.Core.Interfaces;

namespace JPProject.Admin.Application.Services
{
    public class ScopesAppService : IScopesAppService
    {
        private IMapper _mapper;
        private IEventStoreRepository _eventStoreRepository;
        private readonly IIdentityResourceRepository _identityResourcesRepository;
        private readonly IApiScopeRepository _apiResourceRepository;
        public IMediatorHandler Bus { get; set; }

        public ScopesAppService(IMapper mapper,
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository,
            IIdentityResourceRepository identityResourcesRepository,
            IApiScopeRepository apiResourceRepository)
        {
            _mapper = mapper;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
            _identityResourcesRepository = identityResourcesRepository;
            _apiResourceRepository = apiResourceRepository;
        }
        

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<string>> GetScopes(string search)
        {
            var identityScopes = await _identityResourcesRepository.SearchScopes(search);
            var apiScopes = await _apiResourceRepository.SearchScopes(search);
            identityScopes.AddRange(apiScopes.Select(x => x.Name));
            return identityScopes.OrderBy(a => a);
        }
    }
}