using Core.Primitives;

namespace Core.ValueObjects;

/// <summary>
/// Value object that wrappers an Address
/// </summary>
public class Address : ValueObject
{
    public Address(string street, string postalCode, string city, string state)
    {
        Street = street;
        PostalCode = postalCode;
        City = city;
        State = state;
    }
    public string Street { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string City { get; set; } = "";
    public string State { get; set; } = "";
    public override IEnumerable<object> Properties()
    {
        yield return Street;
        yield return PostalCode;
        yield return City;
        yield return State;
    }
}