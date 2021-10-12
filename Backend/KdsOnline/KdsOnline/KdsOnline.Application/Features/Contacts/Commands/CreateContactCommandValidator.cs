using FluentValidation;
using KdsOnline.Application.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.Contacts.Commands
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        private readonly IContactRepositoryAsync _conatctRepositoryAsync;

        public CreateContactCommandValidator(IContactRepositoryAsync conatctRepositoryAsync)
        {
            _conatctRepositoryAsync = conatctRepositoryAsync;

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("{PropertyName} must be a valid email address.")
                .MustAsync(IsEmailUnique).WithMessage("{PropertyName} already exists.")
                .NotNull();
            
            RuleFor(c => c.MobileNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(11).WithMessage("{PropertyName} can not be more than 11 characters.")
                .MinimumLength(10).WithMessage("{PropertyName} can not be less than 10 characters.")
                .MustAsync(IsMobileNumberUnique).WithMessage("{PropertyName} already exists.")
                .NotNull();

            RuleFor(c => c.TelephoneNumber)
                .MaximumLength(11).WithMessage("{PropertyName} can not be more than 11 characters.")
                .MinimumLength(10).WithMessage("{PropertyName} can not be less than 10 characters.");
        }

        private async Task<bool> IsEmailUnique (string email, CancellationToken cancellationToken)
        {
            return await _conatctRepositoryAsync.IsEmailUnique(email);
        }

        private async Task<bool> IsMobileNumberUnique(string mobileNumber, CancellationToken cancellationToken)
        {
            return await _conatctRepositoryAsync.IsMobileNumberUnique(mobileNumber);
        }
    }
}
