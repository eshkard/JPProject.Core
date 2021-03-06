using JPProject.Admin.Domain.Commands.PersistedGrant;
using JPProject.Admin.Domain.Events.PersistedGrant;
using JPProject.Admin.Domain.Interfaces;
using JPProject.Domain.Core.Bus;
using JPProject.Domain.Core.Commands;
using JPProject.Domain.Core.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JPProject.Admin.Domain.CommandHandlers
{
    public class PersistedGrantCommandHandler : CommandHandler,
        IRequestHandler<RemovePersistedGrantCommand, bool>
    {
        private readonly IPersistedGrantRepository _persistedGrantRepository;

        public PersistedGrantCommandHandler(
            IAdimUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            IPersistedGrantRepository persistedGrantRepository) : base(uow, bus, notifications)
        {
            _persistedGrantRepository = persistedGrantRepository;
        }


        public async Task<bool> Handle(RemovePersistedGrantCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false; ;
            }

            // Businness logic here
            _persistedGrantRepository.Remove(request.Key);

            if (await Commit())
            {
                await Bus.RaiseEvent(new PersistedGrantRemovedEvent(request.Key));
                return true;
            }
            return false;
        }

    }
}