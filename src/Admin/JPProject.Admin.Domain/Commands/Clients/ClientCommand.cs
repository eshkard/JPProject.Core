using JPProject.Domain.Core.Commands;

namespace JPProject.Admin.Domain.Commands.Clients
{
    public abstract class ClientCommand : Command
    {
        public IdentityServer4.Models.Client Client { get; protected set; }
        public string OldClientId { get; protected set; }
    }
}