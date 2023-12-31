using FluentValidation;

namespace Application.Commands.Stocks.UpdateStock;

public class UpdateStockCommandValidator : AbstractValidator<UpdateStockCommand>
{
    public UpdateStockCommandValidator()
    {
        RuleFor(o => o.QuantityMl).GreaterThan(0);
    }
}