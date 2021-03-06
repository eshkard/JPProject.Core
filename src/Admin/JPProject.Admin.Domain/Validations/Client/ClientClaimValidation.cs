using FluentValidation;
using JPProject.Admin.Domain.Commands.Clients;

namespace JPProject.Admin.Domain.Validations.Client
{
    public abstract class ClientClaimValidation<T> : AbstractValidator<T> where T : ClientClaimCommand
    {

        protected void ValidateId()
        {
            RuleFor(c => c.Id).GreaterThan(0).WithMessage("Invalid secret");
        }
        protected void ValidateClientId()
        {
            RuleFor(c => c.ClientId).NotEmpty().WithMessage("ClientId must be set");
        }

        protected void ValidateValue()
        {
            RuleFor(c => c.Value).NotEmpty().WithMessage("Secret must be set");
        }
        protected void ValidateKey()
        {
            RuleFor(c => c.Type).NotEmpty().WithMessage("Please ensure you have entered key");
        }
    }
}