using Application.Abstractions.BkMediator;
using Core.Enums;
using Core.Primitives.Result;

namespace Application.Commands.Stocks.CreateStock;

/// <summary>
/// Represents the command for creating a new donor
/// </summary>
public record CreateStockCommand : IBkRequest<Result>
{
    public CreateStockCommand(string description, EBlood bloodType, EBloodRhFactor bloodRhFactor, double quantityMl)
    {
        Description = description;
        BloodType = bloodType;
        BloodRhFactor = bloodRhFactor;
        QuantityMl = quantityMl;
    }
    public string Description { get; set; } = "";
    public EBlood BloodType { get; set; }
    public EBloodRhFactor BloodRhFactor { get; set; }
    public double QuantityMl { get; set; }
    public double MinimumQuantityMl { get; set; }
}