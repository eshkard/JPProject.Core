using JPProject.Admin.Domain.Commands.Clients;

namespace JPProject.Admin.Domain.Validations.Client
{
    public class RemoveClientSecretCommandValidation : ClientSecretValidation<RemoveClientSecretCommand>
    {
        public RemoveClientSecretCommandValidation()
        {
            ValidateClientId();
            ValidateId();
        }
    }
}