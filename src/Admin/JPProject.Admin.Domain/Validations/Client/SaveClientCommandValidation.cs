using JPProject.Admin.Domain.Commands.Clients;

namespace JPProject.Admin.Domain.Validations.Client
{
    public class SaveClientCommandValidation : ClientValidation<SaveClientCommand>
    {
        public SaveClientCommandValidation()
        {
            ValidateClientId();
            ValidateClientName();
            ValidateTrailingSlash();
        }
    }
}