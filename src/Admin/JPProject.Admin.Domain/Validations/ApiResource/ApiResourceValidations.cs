using System;
using FluentValidation;
using JPProject.Admin.Domain.Commands.ApiResource;

namespace JPProject.Admin.Domain.Validations.ApiResource
{
    public abstract class ApiResourceValidation<T> : AbstractValidator<T> where T : ApiResourceCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Resource.Name).NotEmpty().WithMessage("Invalid resource name");
        }
    }
}