using Boilerplate.Contracts.V1.Requests;
using FluentValidation;

namespace Boilerplate.Validators
{
    public class CreateMsSqlValidator : AbstractValidator<CreateMsSqlRequest>
    {
        public CreateMsSqlValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}