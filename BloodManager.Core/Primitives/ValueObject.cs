namespace Core.Primitives;

/// <summary>
/// Abstract class that represents a value object
/// </summary>
/// <remarks>https://martinfowler.com/bliki/EvansClassification.html</remarks>
public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> Properties();
    
    /// <summary>
    /// Checks if the two sequences of properties have the same values and are in the same order.
    /// </summary>
    /// <param name="valueObject"></param>
    /// <returns></returns>
    public bool ValueAreEqual(ValueObject? valueObject)
    {
        return valueObject is not null && valueObject.Properties().SequenceEqual(Properties());
    }
    
    public bool Equals(ValueObject? other)
    {
        if (other == null)
        {
            return false;
        }
        return this == other;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }
        if (obj.GetType() != GetType())
        {
            return false;
        }
        ValueObject valueObject = (ValueObject)obj;
        return this == valueObject;
    }
    public static bool operator==(ValueObject? first, ValueObject? second)
    {
        if (first is null && second is null)
        {
            return true;
        }
        if (first is null || second is null)
        {
            return false;
        }
        return first.ValueAreEqual(second);
    }

    public static bool operator !=(ValueObject? first, ValueObject? second)
    {
        return !(first == second);
    }

    public override int GetHashCode()
    {
        return Properties().GetHashCode();
    }
}