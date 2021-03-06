using FluentValidation.Results;
using JPProject.Admin.Domain.Validations.ApiResource;

namespace JPProject.Admin.Domain.Commands.ApiResource
{
    public class RegisterApiResourceCommand : ApiResourceCommand
    {

        public RegisterApiResourceCommand(IdentityServer4.Models.ApiResource apiResource)
        {
            Resource = apiResource;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterApiResourceCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}