using JPProject.Admin.Domain.Commands.Clients;
using JPProject.Domain.Core.Events;

namespace JPProject.Admin.Domain.Events.Client
{
    public class NewClientEvent : Event
    {
        public ClientType ClientType { get; }
        public string ClientName { get; }

        public NewClientEvent(string clientId, ClientType clientType, string clientName)
            : base(EventTypes.Success)
        {
            AggregateId = clientId;
            ClientType = clientType;
            ClientName = clientName;
        }
    }
}