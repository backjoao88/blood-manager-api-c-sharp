using Core.Enums;
using Core.ValueObjects;

namespace Application.ViewModels;

/// <summary>
/// Represents a simplification of the donor entity
/// </summary>
public sealed class DonorViewModel
{
    public DonorViewModel(Guid id, string firstName, string lastName, string email, Address address, double weight, DateTime birth, EBlood blood, EBloodRhFactor bloodRhFactor, EGenre genre)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Address = address;
        Weight = weight;
        Birth = birth;
        Blood = blood;
        BloodRhFactor = bloodRhFactor;
        Genre = genre;
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }
    public double Weight { get; set; }
    public DateTime Birth { get; set; }
    public EBlood Blood { get; set; }
    public EBloodRhFactor BloodRhFactor { get; set; }
    public EGenre Genre { get; set; }
}