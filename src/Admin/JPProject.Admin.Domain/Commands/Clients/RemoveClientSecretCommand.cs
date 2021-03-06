using JPProject.Admin.Domain.Validations.Client;

namespace JPProject.Admin.Domain.Commands.Clients
{
    public class RemoveClientSecretCommand : ClientSecretCommand
    {

        public RemoveClientSecretCommand(int id, string clientId)
        {
            Id = id;
            ClientId = clientId;
        }


        public override bool IsValid()
        {
            ValidationResult = new RemoveClientSecretCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}