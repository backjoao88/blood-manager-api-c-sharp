using FluentValidation;

namespace Application.Commands.Stocks.CreateStock;

/// <summary>
/// Validates the <see cref="CreateStockCommand"/> input
/// </summary>
public class CreateStockCommandValidator : AbstractValidator<CreateStockCommand>
{
    public CreateStockCommandValidator()
    {
        RuleFor(o => o.BloodType).NotEmpty();
        RuleFor(o => o.QuantityMl).NotEmpty().GreaterThan(0);
        RuleFor(o => o.Description).NotEmpty().MaximumLength(255);
        RuleFor(o => o.BloodType).NotEmpty();
        RuleFor(o => o.BloodRhFactor).NotEmpty();
    }
}