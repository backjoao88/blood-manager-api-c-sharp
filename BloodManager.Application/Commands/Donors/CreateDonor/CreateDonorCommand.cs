using BloodManager.Application.Abstractions.BkMediator;
using Core.Primitives.Result;
using Core.ValueObjects;

namespace Application.Commands.Donors.CreateDonor;

/// <summary>
/// Represents the command for creating a new donor
/// </summary>
public class CreateDonorCommand : IBkRequest<Result>
{
    /// <summary>
    /// Initializes a new instance of this class
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="email"></param>
    /// <param name="address"></param>
    /// <param name="weight"></param>
    /// <param name="birth"></param>
    public CreateDonorCommand(string firstName, string lastName, string email, Address address, double weight, DateTime birth)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Address = address;
        Weight = weight;
        Birth = birth;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }
    public double Weight { get; set; }
    public DateTime Birth { get; set; }
}