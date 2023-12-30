using System.Data;
using FluentValidation;

namespace Application.Commands.Donors.UpdateDonor;

/// <summary>
/// Represents the <see cref="UpdateDonorCommand"/> validator
/// </summary>
public class UpdateDonorCommandValidator : AbstractValidator<UpdateDonorCommand>
{
    public UpdateDonorCommandValidator()
    {
        RuleFor(o => o.FirstName).MaximumLength(255);
        RuleFor(o => o.LastName).MaximumLength(255);
        RuleFor(o => o.Email).EmailAddress().MaximumLength(100);
    }
}