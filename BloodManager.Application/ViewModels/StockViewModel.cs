using Core.Enums;

namespace Application.ViewModels;

/// <summary>
/// Represents a simplification of the stock entity
/// </summary>
public class StockViewModel
{
    public StockViewModel(Guid id, string description, EBlood bloodType, EBloodRhFactor bloodRhFactor, double quantityMl, double minimumQuantityMl)
    {
        Id = id;
        Description = description;
        BloodType = bloodType;
        BloodRhFactor = bloodRhFactor;
        QuantityMl = quantityMl;
        MinimumQuantityMl = minimumQuantityMl;
    }
    public Guid Id { get; set; }
    public string Description { get; set; }
    public EBlood BloodType { get; set; }
    public EBloodRhFactor BloodRhFactor { get; set; }
    public double QuantityMl { get; set; }
    public double MinimumQuantityMl { get; set; }
}