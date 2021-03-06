using JPProject.Admin.Domain.Validations.Client;

namespace JPProject.Admin.Domain.Commands.Clients
{
    public class RemovePropertyCommand : ClientPropertyCommand
    {

        public RemovePropertyCommand(int id, string clientId)
        {
            Id = id;
            ClientId = clientId;
        }


        public override bool IsValid()
        {
            ValidationResult = new RemovePropertyCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}