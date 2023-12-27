using Core.Primitives;

namespace Core.ValueObjects;

/// <summary>
/// Value object that wrappers an E-mail
/// </summary>
public class Email : ValueObject
{
    private Email() { }
    public Email(string value)
    {
        Value = value;
    }
    public string Value { get; set; } = null!;

    public override IEnumerable<object> Properties()
    {
        yield return Value;
    }
}