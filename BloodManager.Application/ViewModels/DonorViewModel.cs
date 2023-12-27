using Core.ValueObjects;

namespace Application.ViewModels;

/// <summary>
/// Represents a simplification of the donor entity
/// </summary>
public sealed class DonorViewModel
{
    public DonorViewModel(Guid id, string firstName, string lastName, string email, Address address, double weight, DateTime birth)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Address = address;
        Weight = weight;
        Birth = birth;
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }
    public double Weight { get; set; }
    public DateTime Birth { get; set; }
}