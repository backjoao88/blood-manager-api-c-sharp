using Application.Abstractions.BkMediator;
using Core.Primitives.Result;

namespace Application.Commands.Stocks.UpdateStock;

/// <summary>
/// Represents a command to increase or decrease blood stock quantity information
/// </summary>
public class UpdateStockCommand: IBkRequest<Result>
{
    public UpdateStockCommand(Guid id, double quantityMl)
    {
        Id = id;
        QuantityMl = quantityMl;
    }
    public Guid Id { get; set; }
    public double QuantityMl { get; set; }
}