using BloodManager.Application.Abstractions.BkMediator;
using Core.Primitives.Result;

namespace Application.Commands.Donations.CreateDonation;

/// <summary>
/// Represents the command for creating a new donation
/// </summary>
public class CreateDonationCommand : IBkRequest<Result>
{
    public CreateDonationCommand(double quantityMl, Guid idDonor)
    {
        QuantityMl = quantityMl;
        IdDonor = idDonor;
    }
    public double QuantityMl { get; set; }
    public Guid IdDonor { get; set; }
}