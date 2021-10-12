using FluentValidation;
using KdsOnline.Application.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace KdsOnline.Application.Features.PersonalDetails
{
    public class CreatePersonalDetailCommandValidator : AbstractValidator<CreatePersonalDetailCommand>
    {
        public IPersonalDetailRepositoryAsync _personalDetailsRepositoryAsync { get; set; }

        public CreatePersonalDetailCommandValidator(IPersonalDetailRepositoryAsync personalDetailsRepositoryAsync)
        {
            _personalDetailsRepositoryAsync = personalDetailsRepositoryAsync;

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MinimumLength(3).WithMessage("{PropertyName} must be above 2 characters.");

            RuleFor(p => p.SecondName)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MinimumLength(3).WithMessage("{PropertyName} must be above 2 characters.");

            RuleFor(p => p.Surname)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MinimumLength(3).WithMessage("{PropertyName} must be above 2 characters.");

            RuleFor(p => p.Gender)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.IdNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.}")
                .MaximumLength(13).WithMessage("{PropertyName} must not exceed 13 characters.}")
                .MinimumLength(13).WithMessage("{PropertyName} must not be less than 13 characters.")                
                .MustAsync(IsUniqueIdNumber).WithMessage("{PropertyName} already exists.")
                .NotNull();

            RuleFor(p => p.Nationality)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }

        private async Task<bool> IsUniqueIdNumber(string idNumber, CancellationToken cancellationToken)
        {
            return await _personalDetailsRepositoryAsync.IsUniqueIdNumberAsync(idNumber);
        }
    }
}
