using System;
using Boilerplate.Contracts;
using Boilerplate.Contracts.V1.Requests;
using FluentValidation;

namespace Boilerplate.Validators
{
    public class CreateRequestValidator : AbstractValidator<CreateRequest>
    {
        /// <summary>
        /// Documentation
        /// https://fluentvalidation.net/
        ///
        /// Built in validators
        /// https://docs.fluentvalidation.net/en/latest/built-in-validators.html
        /// </summary>
        public CreateRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Custom message for empty validation")
                .NotNull().WithMessage("Custom message for null validation")
                .NotEqual("jorn", StringComparer.InvariantCultureIgnoreCase)
                .Length(5, 10)
                .Matches("^[a-zA-Z0-9 ]*$")
                .WithMessage("Invalid name value. Must have between 5 and 10 characters.");
            
            RuleFor(x => x.Email)
                .NotEmpty()
                .When(x => x.Name != string.Empty)
                .Must(CustomValidator)
                .EmailAddress();
        }
        
        private bool CustomValidator(string email)
        {
            return true;
        }
    }
}