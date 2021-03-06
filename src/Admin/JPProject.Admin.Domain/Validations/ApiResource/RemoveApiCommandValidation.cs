using JPProject.Admin.Domain.Commands.ApiResource;
using JPProject.Admin.Domain.Validations.ApiResource;

namespace JPProject.Admin.Domain.Validations.Client
{
    public class RemoveApiCommandValidation : ApiSecretValidation<RemoveApiSecretCommand>
    {
        public RemoveApiCommandValidation()
        {
            ValidateResourceName();
            ValidateId();
        }
    }
}