using Core.Enums;
using Core.Primitives;

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
    public void Update(double quantityMl)
    {
        QuantityMl += quantityMl;
    }
}