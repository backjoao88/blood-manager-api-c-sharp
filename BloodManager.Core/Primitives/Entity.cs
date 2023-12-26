namespace Core.Primitives;

/// <summary>
/// Abstract class that represents an entity
/// </summary>
/// <remarks>https://martinfowler.com/bliki/EvansClassification.html</remarks>
public abstract class Entity
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    /// <summary>
    /// Soft-delete an entity, setting property 'IsDeleted' as false.
    /// </summary>
    public void Delete()
    {
        IsDeleted = true;
    }
}