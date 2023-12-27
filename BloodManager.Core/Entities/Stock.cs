using Core.Enums;
using Core.Primitives;

namespace Core.Entities;

/// <summary>
/// Represents a blood stock
/// </summary>
public class Stock : Entity
{
    public Stock(string description, EBlood bloodType, EBloodRhFactor bloodRhFactor, int quantityMl)
    {
        Description = description;
        BloodType = bloodType;
        BloodRhFactor = bloodRhFactor;
        QuantityMl = quantityMl;
    }
    public Guid Id { get; set; }
    public string Description { get; set; }
    public EBlood BloodType { get; set; }
    public EBloodRhFactor BloodRhFactor { get; set; }
    public int QuantityMl { get; set; }
}