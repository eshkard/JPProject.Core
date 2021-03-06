using JPProject.Domain.Core.Events;

namespace JPProject.Admin.Domain.Events.Client
{
    public class ClientSecretRemovedEvent : Event
    {
        public int SecretId { get; }

        public ClientSecretRemovedEvent(int id, string clientId)
            : base(EventTypes.Success)
        {
            SecretId = id;
            AggregateId = clientId;
        }
    }
}