using IdentityServer4.EntityFramework.Mappers;
using JPProject.Admin.Domain.Commands.ApiResource;
using JPProject.Admin.Domain.Events.ApiResource;
using JPProject.Admin.Domain.Interfaces;
using JPProject.Domain.Core.Bus;
using JPProject.Domain.Core.Commands;
using JPProject.Domain.Core.Notifications;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JPProject.Admin.Domain.CommandHandlers
{
    public class ApiResourceCommandHandler : CommandHandler,
        IRequestHandler<RegisterApiResourceCommand, bool>,
        IRequestHandler<UpdateApiResourceCommand, bool>,
        IRequestHandler<RemoveApiResourceCommand, bool>,
        IRequestHandler<RemoveApiSecretCommand, bool>,
        IRequestHandler<SaveApiSecretCommand, bool>,
        IRequestHandler<RemoveApiScopeCommand, bool>,
        IRequestHandler<SaveApiScopeCommand, bool>
    {
        private readonly IApiResourceRepository _apiResourceRepository;
        private readonly IApiSecretRepository _apiSecretRepository;
        private readonly IApiScopeRepository _apiScopeRepository;

        public ApiResourceCommandHandler(
            IAdimUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            IApiResourceRepository apiResourceService,
            IApiSecretRepository apiSecretRepository,
            IApiScopeRepository apiScopeRepository) : base(uow, bus, notifications)
        {
            _apiResourceRepository = apiResourceService;
            _apiSecretRepository = apiSecretRepository;
            _apiScopeRepository = apiScopeRepository;
        }


        public async Task<bool> Handle(RegisterApiResourceCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var savedClient = await _apiResourceRepository.GetResource(request.Resource.Name);
            if (savedClient != null)
            {
                await Bus.RaiseEvent(new DomainNotification("Api", "Resource already exists"));
                return false;
            }

            var api = request.Resource.ToEntity();
            _apiResourceRepository.Add(api);

            if (await Commit())
            {
                await Bus.RaiseEvent(new ApiResourceRegisteredEvent(request.Resource.Name));
                return true;
            }
            return false;
        }

        public async Task<bool> Handle(UpdateApiResourceCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var savedClient = await _apiResourceRepository.GetResource(request.OldResourceName);
            if (savedClient == null)
            {
                await Bus.RaiseEvent(new DomainNotification("Api", "Resource not found"));
                return false;
            }

            var irs = request.Resource.ToEntity();
            irs.Id = savedClient.Id;
            await _apiResourceRepository.UpdateWithChildrens(irs);

            if (await Commit())
            {
                await Bus.RaiseEvent(new ApiResourceUpdatedEvent(request.Resource));
                return true;
            }
            return false;
        }

        public async Task<bool> Handle(RemoveApiResourceCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var savedClient = await _apiResourceRepository.GetResource(request.Resource.Name);
            if (savedClient == null)
            {
                await Bus.RaiseEvent(new DomainNotification("Api", "Resource not found"));
                return false;
            }

            _apiResourceRepository.Remove(savedClient.Id);

            if (await Commit())
            {
                await Bus.RaiseEvent(new ApiResourceRemovedEvent(request.Resource.Name));
                return true;
            }
            return false;
        }

        public async Task<bool> Handle(RemoveApiSecretCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var savedClient = await _apiResourceRepository.GetResource(request.ResourceName);
            if (savedClient == null)
            {
                await Bus.RaiseEvent(new DomainNotification("Api", "Api not found"));
                return false;
            }

            if (savedClient.Secrets.All(f => f.Id != request.Id))
            {
                await Bus.RaiseEvent(new DomainNotification("Api Secret", "Invalid secret"));
                return false;
            }

            _apiSecretRepository.Remove(request.Id);

            if (await Commit())
            {
                await Bus.RaiseEvent(new ApiSecretRemovedEvent(request.Id, request.ResourceName));
                return true;
            }
            return false;
        }

        public async Task<bool> Handle(SaveApiSecretCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var savedApi = await _apiResourceRepository.GetByName(request.ResourceName);
            if (savedApi == null)
            {
                await Bus.RaiseEvent(new DomainNotification("Api", "Api not found"));
                return false;
            }

            var secret = request.ToEntity(savedApi);
            _apiSecretRepository.Add(secret);

            if (await Commit())
            {
                await Bus.RaiseEvent(new ApiSecretSavedEvent(request.Id, request.ResourceName));
                return true;
            }
            return false;
        }

        public async Task<bool> Handle(RemoveApiScopeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var savedClient = await _apiResourceRepository.GetResource(request.ResourceName);
            if (savedClient == null)
            {
                await Bus.RaiseEvent(new DomainNotification("Api", "Api not found"));
                return false;
            }

            if (savedClient.Scopes.All(f => f.Id != request.Id))
            {
                await Bus.RaiseEvent(new DomainNotification("Api Scope", "Invalid scope"));
                return false;
            }

            var scopeToremove = savedClient.Scopes.First(f => f.Id == request.Id);
            _apiScopeRepository.Remove(scopeToremove.Id);

            if (await Commit())
            {
                await Bus.RaiseEvent(new ApiScopeRemovedEvent(request.Id, request.ResourceName, scopeToremove.Name));
                return true;
            }
            return false;
        }

        public async Task<bool> Handle(SaveApiScopeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var savedApi = await _apiResourceRepository.GetByName(request.ResourceName);
            if (savedApi == null)
            {
                await Bus.RaiseEvent(new DomainNotification("Api", "Api not found"));
                return false;
            }

            var secret = request.ToEntity(savedApi);

            _apiScopeRepository.Add(secret);

            if (await Commit())
            {
                await Bus.RaiseEvent(new ApiSecretSavedEvent(request.Id, request.ResourceName));
                return true;
            }
            return false;
        }
    }
}