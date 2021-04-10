using Boilerplate.Contracts.V1.Requests;
using FluentValidation;

namespace Boilerplate.Validators
{
    public class CreateMySqlValidator : AbstractValidator<CreateMySqlRequest>
    {
        public CreateMySqlValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}