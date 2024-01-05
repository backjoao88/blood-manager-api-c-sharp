using Core.Enums;
using Core.Primitives;
using Core.Primitives.Result;

namespace Core.Entities;

/// <summary>
/// Represents a blood stock
/// </summary>
public class Stock : Entity
{
    public Stock(string description, EBlood bloodType, EBloodRhFactor bloodRhFactor, double quantityMl, double minimumQuantityMl)
    {
        Description = description;
        BloodType = bloodType;
        BloodRhFactor = bloodRhFactor;
        QuantityMl = quantityMl;
        MinimumQuantityMl = minimumQuantityMl;
    }
    public string Description { get; set; }
    public EBlood BloodType { get; set; }
    public EBloodRhFactor BloodRhFactor { get; set; }
    public double QuantityMl { get; set; }
    public double MinimumQuantityMl { get; set; }

    /// <summary>
    /// Checks if the current blood type and RH factor are valid
    /// </summary>
    /// <returns>A result object</returns>
    public Result IsValidBloodType()
    {
        var validBloodTypes = Enum.GetValues(typeof(EBlood)).Cast<int>().ToList();
        if (!validBloodTypes.Contains((int)BloodType)) 
        {
            return Result.Fail(DomainErrors.Stock.NotFoundBloodTypeError);
        }
        var validBloodRhFactor = Enum.GetValues(typeof(EBloodRhFactor)).Cast<int>().ToList();
        if (!validBloodRhFactor.Contains((int)BloodRhFactor)) 
        {
            return Result.Fail(DomainErrors.Stock.NotFoundBloodRhFactorError);
        }
        return Result.Ok();
    }
    /// <summary>
    /// Increases or decreases the blood quantity 
    /// </summary>
    /// <param name="quantityMl"></param>
    /// <returns>A result object</returns>
    public Result Update(double quantityMl)
    {
        var futureStock = QuantityMl + quantityMl;
        if (futureStock <= MinimumQuantityMl)
        {
            return Result.Fail(DomainErrors.Stock.MinimumStockQuantityReachedError);
        }
        QuantityMl += quantityMl;
        return Result.Ok();
    }
}