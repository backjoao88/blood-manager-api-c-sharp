using FluentValidation;

namespace Application.Commands.Donations.CreateDonation;

/// <summary>
/// Validates the <see cref="CreateDonationCommand"/> input
/// </summary>
public class CreateDonationCommandValidator : AbstractValidator<CreateDonationCommand>
{
    public CreateDonationCommandValidator()
    {
        RuleFor(o => o.QuantityMl).NotEmpty().GreaterThan(0);
        RuleFor(o => o.IdDonor).NotEmpty();
    }
}