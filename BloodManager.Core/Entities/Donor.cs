using Core.Primitives;
using Core.ValueObjects;

namespace Core.Entities;

/// <summary>
/// Represents a blood donor
/// </summary>
public class Donor : Entity
{
    /// <summary>
    /// Private donor ctor. Required by EFCore.
    /// </summary>
    private Donor()
    {
    }
    public Donor(string firstName, string lastName, Email email, Address address, double weight, DateTime birth)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Address = address;
        Weight = weight;
        Birth = birth;
    }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Email Email { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public double Weight { get; set; }
    public DateTime Birth { get; set; }
}