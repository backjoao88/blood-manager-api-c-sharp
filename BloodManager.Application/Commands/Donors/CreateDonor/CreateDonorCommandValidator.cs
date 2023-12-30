using Application.Commands.Donations.CreateDonation;
using FluentValidation;

namespace Application.Commands.Donors.CreateDonor;

/// <summary>
/// Validates the <see cref="CreateDonationCommand"/> input
/// </summary>
public class CreateDonorCommandValidator : AbstractValidator<CreateDonorCommand>
{
    public CreateDonorCommandValidator()
    {
        RuleFor(o => o.FirstName).NotEmpty().MaximumLength(255);
        RuleFor(o => o.LastName).NotEmpty().MaximumLength(255);
        RuleFor(o => o.Birth).NotEmpty();
        RuleFor(o => o.Email).NotEmpty().EmailAddress().MaximumLength(100);
        RuleFor(o => o.Weight).NotEmpty().GreaterThan(30);
        RuleFor(o => o.Address.City).NotEmpty();
        RuleFor(o => o.Address.State).NotEmpty();
        RuleFor(o => o.Address.Street).NotEmpty();
        RuleFor(o => o.Address.PostalCode).NotEmpty();
    }
}