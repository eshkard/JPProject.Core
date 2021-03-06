using JPProject.Admin.Domain.Validations.PersistedGrant;

namespace JPProject.Admin.Domain.Commands.PersistedGrant
{
    public class RemovePersistedGrantCommand : PersistedGrantCommand
    {

        public RemovePersistedGrantCommand(string key)
        {
            Key = key;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemovePersistedGrantCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}