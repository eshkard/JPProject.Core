using JPProject.Domain.Core.Events;

namespace JPProject.Admin.Domain.Events.Client
{
    public class ClientClaimRemovedEvent : Event
    {
        public int Id { get; }

        public ClientClaimRemovedEvent(int id, string clientId)
            : base(EventTypes.Success)
        {
            Id = id;
            AggregateId = clientId;
        }
    }
}