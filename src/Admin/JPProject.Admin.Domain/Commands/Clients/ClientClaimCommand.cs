using JPProject.Domain.Core.Commands;

namespace JPProject.Admin.Domain.Commands.Clients
{
    public abstract class ClientClaimCommand : Command
    {
        public int Id { get; protected set; }
        public string ClientId { get; protected set; }
        public string Type { get; protected set; }

        public string Value { get; protected set; }
    }
}