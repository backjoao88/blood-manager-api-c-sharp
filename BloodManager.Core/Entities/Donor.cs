using Core.Enums;
using Core.Primitives;
using Core.Primitives.Result;
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
    private Donor() { }
    public Donor(string firstName, string lastName, Email email, Address address, double weight, DateTime birth, EBlood bloodType, EBloodRhFactor bloodRhFactor, EGenre genre)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Address = address;
        Weight = weight;
        Birth = birth;
        BloodType = bloodType;
        BloodRhFactor = bloodRhFactor;
        Genre = genre;
    }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public double Weight { get; private set; }
    public DateTime Birth { get; private set; }
    public EBlood BloodType { get; private set; }
    public EBloodRhFactor BloodRhFactor { get; private set; }
    public EGenre Genre { get; set; }

    /// <summary>
    /// Calculates the age of the donor based on his birth
    /// </summary>
    /// <returns>A 32bit integer</returns>
    public int CalculateAge()
    {
        var currentYear = DateTime.Today.Year;
        var birthYear = Birth.Year;
        var birthdayPassed = DateTime.Today.Month > Birth.Month;
        return currentYear - birthYear - (birthdayPassed ? 0 : 1);
    }

    /// <summary>
    /// Checks if this donor is a woman
    /// </summary>
    /// <returns>A boolean value</returns>
    public bool IsWoman()
    {
        return Genre == EGenre.Female;
    }

    /// <summary>
    /// Checks if this donor is a man
    /// </summary>
    /// <returns>A boolean value</returns>
    public bool IsMan()
    {
        return Genre == EGenre.Male;
    }
    
    /// <summary>
    /// Checks if this donor is able to donate blood
    /// </summary>
    /// <returns>A bool result object</returns>
    public Result CanDonate()
    {
        const int minAllowedAge = 18;
        const int minAllowedWeight = 50;
        if (CalculateAge() < minAllowedAge)
        {
            return Result.Fail(DomainErrors.Donor.NotAllowedAgeError);
        }
        if (Weight < minAllowedWeight)
        {
            return Result.Fail(DomainErrors.Donor.NotAllowedWeightError);
        }
        return Result.Ok();
    }

    /// <summary>
    /// Checks if the this donor is able to donate within a specific interval
    /// </summary>
    /// <param name="lastDonation"></param>
    /// <returns>A bool result object</returns>
    public Result CheckDonationInterval(DateTime lastDonation)
    {
        const int minIntervalDonationDaysForWoman = 0;
        const int minIntervalDonationDaysForMen = 0;
        var totalDays = DateTime.Now.Subtract(lastDonation).TotalDays;
        var allowedInterval = totalDays - (IsWoman() ? minIntervalDonationDaysForWoman : minIntervalDonationDaysForMen);
        if (allowedInterval < 0)
        {
            return Result.Fail(DomainErrors.Donor.NotInValidIntervalError);
        }   
        return Result.Ok();
    }
    
}