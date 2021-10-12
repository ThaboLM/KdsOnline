using FluentValidation;

namespace KdsOnline.Application.Features.Addresses.Commands
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(c => c.Province)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} can not be more than 50 characters.")
                .NotNull();

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} can not be more than 50 characters.")
                .NotNull();

            RuleFor(c => c.Suburb)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} can not be more than 50 characters.")
                .NotNull();

            RuleFor(c => c.ComplexName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} can not be more than 50 characters.")
                .NotNull();

            RuleFor(c => c.UnitNumber)
                .LessThan(1).WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(c => c.StreetAddress)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} can not be more than 50 characters.")
                .NotNull();

            RuleFor(c => c.PostalCode)
                .LessThan(1).WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
