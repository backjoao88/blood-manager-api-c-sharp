using Core.Primitives;
using Core.Primitives.Result;

namespace Core.Entities;

/// <summary>
/// Represents a blood donation
/// </summary>
public class Donation : Entity
{
    /// <summary>
    /// Required by EFCore.
    /// </summary>
    private Donation() { }
    public Donation(DateTime donationDate, double quantityMl, Guid idDonor)
    {
        DonationDate = donationDate;
        QuantityMl = quantityMl;
        IdDonor = idDonor;
    }
    public DateTime DonationDate { get; private set; }
    public double QuantityMl { get; private set; }
    public Guid? IdDonor { get; private set; }
    public Donor? Donor { get; private set; }

    public Result IsValidQuantity()
    {
        if (QuantityMl < 420 || QuantityMl > 470)
        {
            return Result.Fail(DomainErrors.Donation.NotValidQuantityError);
        }
        return Result.Ok();
    }
}