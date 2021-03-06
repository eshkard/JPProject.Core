using JPProject.Admin.Domain.Commands.Clients;

namespace JPProject.Admin.Domain.Validations.Client
{
    public class RemoveClientClaimCommandValidation : ClientClaimValidation<RemoveClientClaimCommand>
    {
        public RemoveClientClaimCommandValidation()
        {
            ValidateClientId();
            ValidateId();
        }
    }
}